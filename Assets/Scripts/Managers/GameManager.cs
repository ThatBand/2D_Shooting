using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("플레이어 / 보스")]
    public Transform player;
    public Transform boss;

    [Header("")]
    public GameObject scoreItem;

    [Header("일시정지 버튼")]
    public GameObject pauseButton;

    public float playTime;
    public bool isGameClear;

    private bool isGameStart;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        Time.timeScale = 1;
    }

    private void Start()
    {
        if (UIManager.instance.noticePanel.activeSelf)
            GameTimeManager.instance.StopGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (!isGameClear && Time.timeScale > 0 && isGameStart)
        {
            playTime += Time.unscaledDeltaTime;

            UIManager.instance.UpdatePlayTime(playTime);
        }
    }

    public void GameStart()
    {
        isGameStart = true;
        boss.GetComponent<BossPatternManager>().BossMoveStart();
        SoundManager.instance.Change1PhaseBGM();

        pauseButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ClearBullet()
    {
        SoundManager.instance.BulletToCoinSound();

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

        foreach (GameObject bullet in bullets)
        {
            GameObject item = Instantiate(scoreItem, bullet.transform.position, Quaternion.identity);
            ItemFollow follow = item.GetComponent<ItemFollow>();
            ItemMove move = item.GetComponent<ItemMove>();

            move.enabled = false;
            follow.enabled = true;

            Destroy(bullet);
        }
    }
}
