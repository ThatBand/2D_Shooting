using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public AudioClip playerShootingSound;
    public AudioClip[] bossHitSounds;
    public AudioClip grazeSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void PlayerShootSound()
    {
        if (audioSource != null && playerShootingSound != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.05f);
            audioSource.PlayOneShot(playerShootingSound);
        }
    }

    public void GrazeSound()
    {
        if (audioSource != null && grazeSound != null)
        {
            audioSource.PlayOneShot(grazeSound, 0.4f);
        }
    }

    public void BossHitSound()
    {
        if (audioSource != null && bossHitSounds.Length != 0)
        {
            for (int i = 0; i < bossHitSounds.Length; i++)
            {
                audioSource.PlayOneShot(bossHitSounds[i]);
            }
        }
    }
}
