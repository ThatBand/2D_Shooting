using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI curScoreText;
    public TextMeshProUGUI highScoreText;

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI grazeText;

    public Image[] healthIcons;
    public Image[] boomIcons;

    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject noticePanel;

    public Slider timeControlSlider;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void UpdateCurrentScore(int current, int high)
    {
        curScoreText.text = current.ToString("N0");

        highScoreText.text = high.ToString("N0");
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

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OpenNoticePanel()
    {
        settingPanel.SetActive(false);
        noticePanel.SetActive(true);
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        GameTimeManager.instance.NormalMode();
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
        GameTimeManager.instance.NormalMode();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseButton()
    {
        if (!settingPanel.activeSelf && !noticePanel.activeSelf)
            OpenPausePanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.activeSelf && !settingPanel.activeSelf && !noticePanel.activeSelf)
            OpenPausePanel();

        else if (Input.GetKeyDown(KeyCode.Escape) && noticePanel.activeSelf)
            noticePanel.GetComponent<GuidePanelManager>()?.CloseNotice();

        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf)
            ClosePausePanel();

        else if (Input.GetKeyDown(KeyCode.Escape) && settingPanel.activeSelf)
            CloseSettingPanel();
    }
}