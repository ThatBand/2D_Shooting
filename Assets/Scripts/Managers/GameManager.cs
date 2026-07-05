using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;
    public PlayerShooter playerShooter;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);

        Time.timeScale = 1;
    }
}
