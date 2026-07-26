using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI grazeText;

    public Image[] healthIcons;
    public Image[] boomIcons;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    public GameObject pausePanel;

    public Slider timeControlSlider;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"{score:n0}";
    }

    public void UpdatePower(int power)
    {
        powerText.text = $"{power:n0}";
    }

    public void UpdateMaxPower()
    {
        powerText.text = "MAX";
    }

    public void UpdateGraze(int graze)
    {
        grazeText.text = $"{graze:n0}";
    }

    public void HitHealthIcon(int health)
    {
        if (health >= 0)
            healthIcons[health].gameObject.SetActive(false);
    }

    public void HealHealthIcon(int health)
    {
        healthIcons[health - 1].gameObject.SetActive(true);
    }

    public void GetBoomIcon(int count)
    {
        boomIcons[count - 1].gameObject.SetActive(true);
    }

    public void UseBoomIcon(int count)
    {
        boomIcons[count].gameObject.SetActive(false);
    }

    public void SetGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void SetGameClearPanel()
    {
        gameClearPanel.SetActive(true);
    }

    public void UpdateSlider(float curValue, float maxValue)
    {
        timeControlSlider.value = curValue / maxValue;
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        GameTimeManager.instance.StopGame();
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        GameTimeManager.instance.NormalMode();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.activeSelf)
        {
            OpenPausePanel();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf)
        {
            ClosePausePanel();        
        }
    }
}