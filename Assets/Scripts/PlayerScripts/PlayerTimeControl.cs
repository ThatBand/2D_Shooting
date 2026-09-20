using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeControl : MonoBehaviour
{
    public UIManager uiManager;

    public float maxGauge;
    public float curGauge;

    public float decreaseSpeed;
    public float increaseSpeed;

    public bool isCooldown;

    private Coroutine increaseRoutine;
    private PlayerTrail trail;

    private void Awake()
    {
        curGauge = maxGauge;
        
        trail = GetComponent<PlayerTrail>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.isPause || GetComponent<PlayerHealth>().isDead)
            return;

        if (curGauge < 0.1 && !isCooldown)
        {
            curGauge = 0;
            isCooldown = true;
            GameTimeManager.instance.NormalMode();
            StartIncreaseGauge();
            uiManager.UpdateSlider(curGauge, maxGauge);

            SoundManager.instance.mixer.SetFloat("BgmCutOff", 5000f);

            trail.StopTrail();
        }

        if (Input.GetKey(KeyCode.LeftShift) && !isCooldown && curGauge > 0.0001)
        {
            GameTimeManager.instance.SlowMode();
            curGauge = Mathf.Max(curGauge - decreaseSpeed * Time.unscaledDeltaTime, 0);

            //UI, 사운드, 이펙트 효과
            uiManager.UpdateSlider(curGauge, maxGauge);

            SoundManager.instance.PlayFocusInSound();
            trail.StartTrail();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCooldown)
        {
            GameTimeManager.instance.NormalMode();
            StartIncreaseGauge();

            //UI, 사운드, 이펙트 효과
            uiManager.UpdateSlider(curGauge, maxGauge);

            SoundManager.instance.PlayFocusOutSound();
            trail.StopTrail();
        }
    }

    public void AddGauge(float amount)
    {
        curGauge = Mathf.Min(curGauge + amount, maxGauge);
        uiManager.UpdateSlider(curGauge, maxGauge);
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
            curGauge = Mathf.Min(curGauge + increaseSpeed * Time.unscaledDeltaTime, maxGauge);
            uiManager.UpdateSlider(curGauge, maxGauge);

            yield return null;
        }

        curGauge = maxGauge;
        isCooldown = false;
    }
}
