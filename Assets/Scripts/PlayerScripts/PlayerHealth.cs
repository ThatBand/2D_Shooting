using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int curHealth;

    public UIManager uiManager;
    private PlayerInvincibility playerInvincibility;
    public Graze graze;

    //누구나 읽을 수 있지만, 수정은 이 스크립트만 할 수 있음
    public bool isDead { get; private set; } = false;

    public event Action OnDamaged;

    private void Awake()
    {
        playerInvincibility = GetComponent<PlayerInvincibility>();
        curHealth = maxHealth;
    }

    public void TakeDamage()
    {
        if (playerInvincibility.IsInvincibility || isDead)
            return;

        curHealth--;
        uiManager.HitHealthIcon(curHealth);

        if (curHealth == 0)
        {
            isDead = true;
            GameTimeManager.instance.StopGame();
            uiManager.SetGameOverPanel();
            return;
        }

        OnDamaged?.Invoke();
    }

}
