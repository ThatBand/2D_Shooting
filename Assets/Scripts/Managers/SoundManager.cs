using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("오디오 믹서")]
    public AudioMixer mixer;

    [Header("배경음 소스")]
    public AudioSource bgmSource;

    [Header("효과음 소스")]
    public AudioSource playerSFXSource;
    public AudioSource enemySFXSource;
    public AudioSource bossSFXSound;
    public AudioSource systemSFXSource;

    [Header("오디오 클립")]

    [Header("BGM 클립")]
    public AudioClip bgm_0;
    public AudioClip bgm_1;
    public AudioClip bgm_2;

    [Header("플레이어 발사 효과음")]
    public AudioClip playerMainShootSound;
    public AudioClip playerSubShootSound;
    public AudioClip playerInduceShootSound;

    [Header("플레이어 사망 효과음")]
    public AudioClip playerDeathSound;

    [Header("그레이즈 효과음")]
    public AudioClip grazeSound;

    [Header("시간 감속 사용 / 해제 효과음")]
    public AudioClip focusInSound;
    public AudioClip focusOutSound;

    [Header("폭탄 효과음")]
    public AudioClip getBombSound;
    public AudioClip useBombSound;

    [Header("파워업 효과음")]
    public AudioClip powerUpSound;

    [Header("파랑 총알 충돌 효과음")]
    public AudioClip blueBulletSound;

    [Header("ㅤ")]
    public AudioClip bullet2CoinSound;

    [Header("보스 히트 효과음")]
    public AudioClip bossNormalHitSound;
    public AudioClip bossCriticalHitSound;

    [Header("적 효과음")]
    public AudioClip enemyShootSound;
    public AudioClip enemyDeathSound;

    [Header("위험 효과음")]
    public AudioClip warningSound;

    [Header("보스 발사 효과음")]
    public AudioClip laserSound;

    [Header("ㅤ")]
    public AudioClip bossShotSound_0;
    public AudioClip bossShotSound_1;
    public AudioClip bossShotSound_2;
    public AudioClip bossShotSound_3;
    public AudioClip bossShotSound_4;

    [Header("ㅤ")]
    public AudioClip createQuartz;

    [Header("보스 폭파 사운드")]
    public AudioClip bossBreakSound;
    public AudioClip bossExplosionSound;

    [Header("게임 클리어 / 오버 사운드")]
    public AudioClip gameClearSound;
    public AudioClip gameOverSound;

    [Header("점수 카운트 / 하이스코어 갱신 사운드")]
    public AudioClip scoreCountSound;
    public AudioClip highScoreSound;

    [Header("버튼 클릭 사운드")]
    public AudioClip buttonClickSound;

    private float lastHitSoundTime;
    private float hitSoundCooldown = 0.05f;

    private bool isFocus;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    public void ButtonClickSound()
    {
        if (systemSFXSource != null && buttonClickSound != null)
        {
            systemSFXSource.PlayOneShot(buttonClickSound, 0.75f);
        }
    }

    public void PlayFocusInSound()
    {
        if (isFocus)
            return;

        isFocus = true;

        if (systemSFXSource != null && focusInSound != null)
        {
            systemSFXSource.Stop();
            systemSFXSource.PlayOneShot(focusInSound, 1f);
        }

        mixer.SetFloat("BgmCutOff", 500f);
    }

    public void PlayFocusOutSound()
    {
        if (!isFocus)
            return;

        isFocus = false;

        if (systemSFXSource != null && focusOutSound != null)
        {
            systemSFXSource.Stop();
            systemSFXSource.PlayOneShot(focusOutSound, 0.5f);
        }

        mixer.SetFloat("BgmCutOff", 5000f);
    }

    public void Change1PhaseBGM()
    {
        if (bgmSource != null && bgm_0 != null)
            bgmSource.PlayOneShot(bgm_0, 0.3f);
    }

    public void Change2PhaseBGM()
    {
        if (bgmSource != null && bgm_1 != null)
        {
            bgmSource.Stop();
            bgmSource.PlayOneShot(bgm_1, 0.3f);
        }
    }

    public void Change3PhaseBGM()
    {
        if (bgmSource != null && bgm_2 != null)
        {
            bgmSource.Stop();
            bgmSource.PlayOneShot(bgm_2, 0.3f);
        }
    }

    public void SetPauseBGM(bool isPaused)
    {
        if (isPaused)
            bgmSource.Pause();

        else
            bgmSource.UnPause();
    }

    public void ScoreSound()
    {
        if (systemSFXSource != null && scoreCountSound != null)
            systemSFXSource.PlayOneShot(scoreCountSound, 0.2f);
    }

    public void HighScoreSound()
    {
        if (systemSFXSource != null && highScoreSound != null)
            systemSFXSource.PlayOneShot(highScoreSound, 0.6f);
    }

    public void GameClearSound()
    {
        if (systemSFXSource != null && gameClearSound != null)
            systemSFXSource.PlayOneShot(gameClearSound, 0.2f);

        bgmSource.Stop();
    }

    public void GameOverSound()
    {
        if (systemSFXSource != null && gameOverSound != null)
            systemSFXSource.PlayOneShot(gameOverSound, 0.2f);

        bgmSource.Stop();
    }

    public void BossExplosionSound()
    {
        if (bossSFXSound != null && bossExplosionSound != null)
            bossSFXSound.PlayOneShot(bossExplosionSound, 0.2f);
    }

    public void CreateQuartz()
    {
        if (systemSFXSource != null && createQuartz != null)
        {
            systemSFXSource.pitch = Random.Range(0.3f, 0.6f);
            systemSFXSource.PlayOneShot(createQuartz, 0.5f);

            systemSFXSource.pitch = 1;
        }
    }

    public void WarningSound()
    {
        if (systemSFXSource != null && warningSound != null)
            systemSFXSource.PlayOneShot(warningSound, 0.5f);
    }

    public void BulletToCoinSound()
    {
        if (systemSFXSource != null && bullet2CoinSound != null)
            systemSFXSource.PlayOneShot(bullet2CoinSound, 0.5f);
    }

    public void PlayerDeathSound()
    {
        if (playerSFXSource != null && playerDeathSound != null)
        {
            playerSFXSource.PlayOneShot(playerDeathSound, 0.25f);
        }
    }

    public void PlayerMainShootSound()
    {
        if (playerSFXSource != null && playerMainShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.9f, 1.05f);
            playerSFXSource.PlayOneShot(playerMainShootSound, 0.2f);

            playerSFXSource.pitch = 1;
        }
    }

    public void PlayerSubShootSound()
    {
        if (playerSFXSource != null && playerSubShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.6f, 0.8f);
            playerSFXSource.PlayOneShot(playerSubShootSound, 0.15f);

            playerSFXSource.pitch = 1;
        }
    }

    public void PlayerInduceShootSound()
    {
        if (playerSFXSource != null && playerInduceShootSound != null)
        {
            playerSFXSource.pitch = Random.Range(0.45f, 0.6f);
            playerSFXSource.PlayOneShot(playerInduceShootSound, 0.1f);

            playerSFXSource.pitch = 1;
        }
    }

    public void GrazeSound()
    {
        if (systemSFXSource != null && grazeSound != null)
        {
            systemSFXSource.pitch = Random.Range(0.45f, 0.6f);
            systemSFXSource.PlayOneShot(grazeSound, 0.3f);

            systemSFXSource.pitch = 1;
        }
    }

    public void PowerUpSound()
    {
        if (systemSFXSource != null && powerUpSound != null)
        {
            systemSFXSource.PlayOneShot(powerUpSound, 0.1f);
        }
    }

    public void BlueBulletSound()
    {
        if (systemSFXSource != null && blueBulletSound != null)
        {
            systemSFXSource.PlayOneShot(blueBulletSound, 0.2f);
        }
    }

    public void GetBombSound()
    {
        if (systemSFXSource != null && getBombSound != null)
        {
            systemSFXSource.PlayOneShot(getBombSound);
        }
    }

    public void UseBombSound()
    {
        if (systemSFXSource != null && useBombSound != null)
        {
            systemSFXSource.PlayOneShot(useBombSound, 1f);
        }
    }

    public void BossNormalHitSound()
    {
        if (bossSFXSound != null && bossNormalHitSound != null)
        {
            if (Time.time - lastHitSoundTime >= hitSoundCooldown)
            {
                bossSFXSound.pitch = Random.Range(0.6f, 1f);
                bossSFXSound.PlayOneShot(bossNormalHitSound, 0.3f);
                lastHitSoundTime = Time.time;

                bossSFXSound.pitch = 1;
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
                bossSFXSound.PlayOneShot(bossCriticalHitSound, 0.4f);
                lastHitSoundTime = Time.time;

                bossSFXSound.pitch = 1;
            }
        }
    }

    public void BossShotSound_0()
    {
        if (bossSFXSound != null && bossShotSound_0 != null)
        {
            bossSFXSound.pitch = Random.Range(0.8f, 1f);
            bossSFXSound.PlayOneShot(bossShotSound_0, 0.3f);

            bossSFXSound.pitch = 1;
        }
    }

    public void BossShotSound_1()
    {
        if (bossSFXSound != null && bossShotSound_1 != null)
        {
            bossSFXSound.pitch = Random.Range(0.3f, 0.5f);
            bossSFXSound.PlayOneShot(bossShotSound_1, 0.05f);

            bossSFXSound.pitch = 1;
        }
    }

    public void BossShotSound_2()
    {
        if (bossSFXSound != null && bossShotSound_2 != null)
        {
            bossSFXSound.pitch = Random.Range(0.3f, 0.5f);
            bossSFXSound.PlayOneShot(bossShotSound_2, 0.4f);

            bossSFXSound.pitch = 1;
        }
    }

    public void BossShotSound_3()
    {
        if (bossSFXSound != null && bossShotSound_3 != null)
        {
            bossSFXSound.PlayOneShot(bossShotSound_3, 0.15f);
        }
    }

    public void BossShotSound_4()
    {
        if (bossSFXSound != null && bossShotSound_4 != null)
        {
            bossSFXSound.pitch = Random.Range(0.9f, 1.05f);
            bossSFXSound.PlayOneShot(bossShotSound_4, 0.15f);

            bossSFXSound.pitch = 1;
        }
    }

    public void BossBreakSound()
    {
        if (bossSFXSound != null && bossBreakSound != null)
        {
            bossSFXSound.pitch = Random.Range(0.05f, 0.4f);
            bossSFXSound.PlayOneShot(bossBreakSound, 0.05f);

            bossSFXSound.pitch = 1;
        }
    }

    public void EnemyShootSound()
    {
        if (enemySFXSource != null && enemyShootSound != null)
        {
            enemySFXSource.pitch = Random.Range(0.8f, 1f);
            enemySFXSource.PlayOneShot(enemyShootSound, 0.15f);

            enemySFXSource.pitch = 1;
        }
    }

    public void EnemyDeathSound()
    {
        if (enemySFXSource != null && enemyDeathSound != null)
        {
            enemySFXSource.pitch = Random.Range(0.8f, 1f);
            enemySFXSource.PlayOneShot(enemyDeathSound, 0.15f);

            enemySFXSource.pitch = 1;
        }
    }

    public void LaserSound()
    {
        if (systemSFXSource != null && laserSound != null)
        {
            systemSFXSource.pitch = Random.Range(0.5f, 0.8f);
            systemSFXSource.PlayOneShot(laserSound, 0.15f);

            systemSFXSource.pitch = 1;
        }
    }
}
