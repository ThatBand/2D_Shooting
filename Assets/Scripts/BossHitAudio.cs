using UnityEngine;

public class BossHitAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip bossHitClip;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        bossHitClip = GenerateBossHitSound();
    }

    // 피격 시 이 함수만 호출하면 됨!
    public void PlayHitSound()
    {
        // 연사 시 소리가 겹쳐 뭉개지지 않도록 피치를 미세하게 다르게 조절
        audioSource.pitch = Random.Range(0.95f, 1.05f);
        audioSource.PlayOneShot(bossHitClip, 0.6f); // 볼륨 60%
    }

    private AudioClip GenerateBossHitSound()
    {
        int sampleRate = 44100;
        float duration = 0.05f; // 0.05초의 짧은 피격음 (연사 대응)
        int sampleCount = (int)(sampleRate * duration);
        float[] samples = new float[sampleCount];

        for (int i = 0; i < sampleCount; i++)
        {
            float t = (float)i / sampleRate;
            float progress = i / (float)sampleCount;
            float envelope = 1f - progress; // 점점 작아지는 감쇄 곡선

            // 금속 피격음: 높은 주파수(900Hz)에서 낮은 주파수(180Hz)로 급강하
            float freq = Mathf.Lerp(900f, 180f, progress);
            
            // 8비트 특유의 각진 사각파(Square Wave) + 노이즈 믹스
            float square = Mathf.Sign(Mathf.Sin(2f * Mathf.PI * freq * t));
            float noise = (Random.value * 2f - 1f) * 0.4f; // 쇠 충돌 노이즈

            samples[i] = (square * 0.6f + noise) * envelope;
        }

        AudioClip clip = AudioClip.Create("GeneratedBossHit", sampleCount, 1, sampleRate, false);
        clip.SetData(samples, 0);
        return clip;
    }
}