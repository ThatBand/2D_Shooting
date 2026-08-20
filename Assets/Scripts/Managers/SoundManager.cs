using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("배경음 소스")]
    public AudioSource bgmSource;

    [Header("효과음 소스")]
    public AudioSource playerSFXSource;
    public AudioSource enemySFXSource;
    public AudioSource systemSFXSource;

    [Header("오디오 클립")]

    [Header("플레이어 발사 효과음")]
    public AudioClip playerMainShootSound;
    public AudioClip playerSubShootSound;
    public AudioClip playerInduceShootSound;

    [Header("플레이어 사망 효과음")]
    public AudioClip playerDeathSound;

    [Header("그레이즈 효과음")]
    public AudioClip grazeSound;

    [Header("폭탄 효과음")]
    public AudioClip getBombSound;
    public AudioClip useBombSound;

    [Header("파워업 효과음")]
    public AudioClip powerUpSound;

    [Header("보스 히트 효과음")]
    public AudioClip bossNormalHitSound;
    public AudioClip bossCriticalHitSound;

    [Header("적  효과음")]
    public AudioClip enemyShootSound;
    public AudioClip enemyDeathSound;

    public AudioClip laserSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void PlayerDeathSound()
    {
        if (playerSFXSource != null && playerDeathSound != null)
        {
            playerSFXSource.PlayOneShot(playerDeathSound, 0.2f);
        }
    }

    public void PlayerMainShootSound()
    {
        if (playerSFXSource != null && playerMainShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.9f, 1.05f);
            playerSFXSource.PlayOneShot(playerMainShootSound, 0.15f);
        }
    }

    public void PlayerSubShootSound()
    {
        if (playerSFXSource != null && playerSubShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.6f, 0.8f);
            playerSFXSource.PlayOneShot(playerSubShootSound, 0.05f);
        }
    }

    public void PlayerInduceShootSound()
    {
        if (playerSFXSource != null && playerInduceShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.45f, 0.6f);
            playerSFXSource.PlayOneShot(playerInduceShootSound, 0.05f);
        }
    }

    public void GrazeSound()
    {
        if (systemSFXSource != null && grazeSound != null)
        {
            systemSFXSource.pitch = Random.Range(0.45f, 0.6f);
            systemSFXSource.PlayOneShot(grazeSound, 0.25f);
        }
    }

    public void PowerUpSound()
    {
        if (systemSFXSource != null && powerUpSound != null)
        {
            systemSFXSource.PlayOneShot(powerUpSound, 0.05f);
        }
    }

    public void GetBombSound()
    {
        if (systemSFXSource != null && getBombSound != null)
        {
            systemSFXSource.PlayOneShot(getBombSound);
        }
    }

    public void BossNormalHitSound()
    {
        if (enemySFXSource != null && bossNormalHitSound != null)
        {
            enemySFXSource.PlayOneShot(bossNormalHitSound, 0.5f);
        }
    }

    public void BossCriticalHitSound()
    {
        if (enemySFXSource != null && bossCriticalHitSound != null)
        {
            enemySFXSource.PlayOneShot(bossCriticalHitSound, 0.5f);
        }
    }

    public void EnemyShootSound()
    {
        if (enemySFXSource != null && enemyShootSound != null)
        {
            enemySFXSource.pitch = Random.Range(0.8f, 1f);
            enemySFXSource.PlayOneShot(enemyShootSound, 0.15f);
        }
    }

    public void EnemyDeathSound()
    {
        if (enemySFXSource != null && enemyDeathSound != null)
        {
            enemySFXSource.pitch = Random.Range(0.8f, 1f);
            enemySFXSource.PlayOneShot(enemyDeathSound, 0.15f);
        }
    }

    public void LaserSound()
    {
        if (systemSFXSource != null && laserSound != null)
        {
            systemSFXSource.pitch = Random.Range(0.5f, 0.8f);
            systemSFXSource.PlayOneShot(laserSound, 0.15f);
        }
    }
}
