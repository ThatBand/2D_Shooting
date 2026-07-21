using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public static GameTimeManager instance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Time.timeScale = 2;
    }

    private void Awake()
    {
        instance = this;

        Time.timeScale = 1;
    }

    public void SlowMode()
    {
        Time.timeScale = 0.5f;
    }

    public void NormalMode()
    {
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }
}
