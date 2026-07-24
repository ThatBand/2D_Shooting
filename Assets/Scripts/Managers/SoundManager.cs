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
    public AudioClip playerShootingSound;
    public AudioClip grazeSound;
    public AudioClip getBombSound;
    public AudioClip bossNormalHitSound;
    public AudioClip bossCriticalHitSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void PlayerShootSound()
    {
        if (playerSFXSource != null && playerShootingSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.9f, 1.05f);
            playerSFXSource.PlayOneShot(playerShootingSound, 0.15f);
        }
    }

    public void GrazeSound()
    {
        if (systemSFXSource != null && grazeSound != null)
        {
            systemSFXSource.PlayOneShot(grazeSound, 0.4f);
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
}
