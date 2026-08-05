using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathEffect : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerShooter playerShooter;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameManager.instance.player.GetComponent<PlayerMove>();
        playerShooter = GameManager.instance.player.GetComponent<PlayerShooter>();
    }

    public void BossDeath()
    {
        GameManager.instance.ClearBullet();
        GameManager.instance.player.GetComponent<Collider2D>().enabled = false;
    }
}