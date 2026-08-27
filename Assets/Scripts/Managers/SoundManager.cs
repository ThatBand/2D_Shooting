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
    public AudioSource bossSFXSound;
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

    [Header("파랑 총알 충돌 효과음")]
    public AudioClip blueBulletSound;

    [Header("보스 히트 효과음")]
    public AudioClip bossNormalHitSound;
    public AudioClip bossCriticalHitSound;

    [Header("적  효과음")]
    public AudioClip enemyShootSound;
    public AudioClip enemyDeathSound;

    [Header("보스 발사 효과음")]
    public AudioClip laserSound;
    public AudioClip bossShotSound_0;
    public AudioClip bossShotSound_1;
    public AudioClip bossShotSound_2;

    private float lastHitSoundTime;
    private float hitSoundCooldown = 0.05f;

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

    public void BlueBulletSound()
    {
        if (systemSFXSource != null && blueBulletSound != null)
        {
            systemSFXSource.PlayOneShot(blueBulletSound, 0.15f);
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
        if (bossSFXSound != null && bossNormalHitSound != null)
        {
            if (Time.time - lastHitSoundTime >= hitSoundCooldown)
            {
                bossSFXSound.pitch = Random.Range(0.6f, 1f);
                bossSFXSound.PlayOneShot(bossNormalHitSound, 0.15f);
                lastHitSoundTime = Time.time;
            }
        }
    }

    public void BossCriticalHitSound()
    {
        if (bossSFXSound != null && bossCriticalHitSound != null)
        {
            if (Time.time - lastHitSoundTime >= hitSoundCooldown)
            {
                bossSFXSound.pitch = Random.Range(0.7f, 1f);
                bossSFXSound.PlayOneShot(bossCriticalHitSound, 0.2f);
                lastHitSoundTime = Time.time;
            }
        }
    }

    public void BossShotSound_0()
    {
        if (bossSFXSound != null && bossShotSound_0 != null)
        {
            bossSFXSound.pitch = Random.Range(0.8f, 1f);
            bossSFXSound.PlayOneShot(bossShotSound_0, 0.3f);
        }
    }

    public void BossShotSound_1()
    {
        if (bossSFXSound != null && bossShotSound_1 != null)
        {
            bossSFXSound.pitch = Random.Range(0.3f, 0.5f);
            bossSFXSound.PlayOneShot(bossShotSound_1, 0.05f);
        }
    }

    public void BossShotSound_2()
    {
        if (bossSFXSound != null && bossShotSound_2 != null)
        {
            bossSFXSound.pitch = Random.Range(0.3f, 0.5f);
            bossSFXSound.PlayOneShot(bossShotSound_2, 0.4f);
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
