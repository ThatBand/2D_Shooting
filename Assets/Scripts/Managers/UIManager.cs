using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("점수 텍스트")]
    public TextMeshProUGUI curScoreText;
    public TextMeshProUGUI highScoreText;

    [Header("ㅤ")]
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI grazeText;

    [Header("ㅤ")]
    public TextMeshProUGUI playTimeText;

    public Image[] healthIcons;
    public Image[] boomIcons;

    [Header("게임 오버 / 클리어 패널")]
    public GameOverUI gameOverPanel;
    public StageClearUI gameClearPanel;

    [Header("정보 패널")]
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject volumeSetPanel;
    public GameObject noticePanel;

    public Slider timeControlSlider;

    public bool isPause;

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

    public void UpdatePlayTime(float time)
    {
        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.FloorToInt(time % 60f);

        playTimeText.text = $"{min:00}:{sec:00}";
    }

    public void SetGameClearPanel()
    {
        gameClearPanel.ShowClearUI(GameManager.instance.playTime,
                                                GameManager.instance.player.GetComponentInChildren<Graze>().grazeCount,
                                                GameManager.instance.player.GetComponent<PlayerHealth>().curHealth,
                                                GameManager.instance.player.GetComponent<PlayerInventory>().curBoomCount,
                                                ScoreManager.instance.stageScore);
    }

    public void SetGameOverPanel()
    {
        gameOverPanel.ShowGameOverUI(GameManager.instance.playTime,
                                     GameManager.instance.player.GetComponentInChildren<Graze>().grazeCount,
                                     ScoreManager.instance.stageScore);
    }

    public void UpdateSlider(float curValue, float maxValue)
    {
        timeControlSlider.value = curValue / maxValue;
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        GameTimeManager.instance.StopGame();

        isPause = true;
    }

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OpenVolumeSettingPanel()
    {
        volumeSetPanel.SetActive(true);
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

        isPause = false;
    }

    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
        GameTimeManager.instance.NormalMode();

        isPause = false;
    }

    public void CloseVolumeSettingPanel()
    {
        volumeSetPanel.SetActive(false);
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

        else if (Input.GetKeyDown(KeyCode.Escape) && settingPanel.activeSelf && volumeSetPanel.activeSelf)
            CloseVolumeSettingPanel();

        else if (Input.GetKeyDown(KeyCode.Escape) && settingPanel.activeSelf)
            CloseSettingPanel();
    }
}