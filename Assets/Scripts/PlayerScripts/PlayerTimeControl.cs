using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeControl : MonoBehaviour
{
    public UIManager uiManager;

    public float maxGauge;
    public float curGauge;

    public int decreaseSpeed;
    public int increaseSpeed;

    public bool isCooldown;

    private Coroutine increaseRoutine;

    private void Awake()
    {
        curGauge = maxGauge;
    }

    // Update is called once per frame
    void Update()
    {
        if (curGauge < 0.1 && !isCooldown)
        {
            curGauge = 0;
            isCooldown = true;
            GameTimeManager.instance.NormalMode();
            StartIncreaseGauge();
            uiManager.UpdateSlider(curGauge, maxGauge);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isCooldown)
        {
            GameTimeManager.instance.SlowMode();
            curGauge -= decreaseSpeed * Time.deltaTime;

            uiManager.UpdateSlider(curGauge, maxGauge);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCooldown)
        {
            GameTimeManager.instance.NormalMode();
            StartIncreaseGauge();

            uiManager.UpdateSlider(curGauge, maxGauge);
        }
    }

    public void StartIncreaseGauge()
    {
        if (increaseRoutine != null)
            StopCoroutine(increaseRoutine);

        increaseRoutine = StartCoroutine(IncreaseGauge());
    }

    IEnumerator IncreaseGauge()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        while (curGauge < maxGauge)
        {
            curGauge += increaseSpeed * Time.deltaTime;
            uiManager.UpdateSlider(curGauge, maxGauge);

            yield return null;
        }

        curGauge = maxGauge;
        isCooldown = false;
    }
}
