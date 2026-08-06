using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager instance;

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
            Time.timeScale = 2;

        if (Input.GetKeyUp(KeyCode.F))
            Time.timeScale = 1;
    }

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1;
    }

    public void SlowMode()
    {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void NormalMode()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public IEnumerator HitStopGame(float time)
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        Time.timeScale = 1;
    }
}
