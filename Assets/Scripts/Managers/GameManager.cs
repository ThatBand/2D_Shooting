using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;
    public Transform boss;
    public PlayerShooter playerShooter;

    public GameObject scoreItem;

    public float playTime;
    public bool isGameClear;

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

    private void Update()
    {
        if (!isGameClear && Time.timeScale > 0)
        {
            playTime += Time.unscaledDeltaTime;

            UIManager.instance.UpdatePlayTime(playTime);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ClearBullet()
    {
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
