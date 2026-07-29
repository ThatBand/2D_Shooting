using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;
    public Transform boss;
    public PlayerShooter playerShooter;

    public GameObject scoreItem;

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
