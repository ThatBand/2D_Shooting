using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDeathEffect : MonoBehaviour
{
    public GameObject particle;
    public Image flashImg;

    public Transform[] particlePos;

    public float flashTime;

    public float fallDur;

    private PlayerMove playerMove;
    private PlayerShooter playerShooter;
    private BossPatternManager manager;
    private EnemyHit hit;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool particleEnd;

    private Vector3 startPos;
    private Vector3 targetPos = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameManager.instance.player.GetComponent<PlayerMove>();
        playerShooter = GameManager.instance.player.GetComponent<PlayerShooter>();
        hit = GetComponent<EnemyHit>();
        manager = GetComponent<BossPatternManager>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        startPos = transform.position;
    }

    public void BossDeath()
    {
        StartCoroutine(BossDeathRoutine());
    }

    IEnumerator BossDeathRoutine()
    {
        manager.StopBossPattern();

        GameManager.instance.player.GetComponentInChildren<Collider2D>().enabled = false;
        playerMove.StopPlayer();
        playerMove.enabled = false;
        playerShooter.enabled = false;
        anim.enabled = false;
        GameManager.instance.ClearBullet();

        GameTimeManager.instance.HitStopGame(0.15f);

        yield return new WaitForSeconds(1);

        StartCoroutine(ParticlePlay());
    }

    IEnumerator ParticlePlay()
    {
        for (int i = 0; i < particlePos.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);

            Instantiate(particle, particlePos[i].position, Quaternion.identity);
            CameraShake.instance.Shake(0.05f, 0.05f);
        }

        yield return new WaitForSeconds(2);

        StartCoroutine(BossCrash());
    }

    IEnumerator BossCrash()
    {
        float timer = 0f;

        while (timer < fallDur)
        {
            timer += Time.deltaTime;
            float progress = timer / fallDur;

            float accelProgress = progress * progress;

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.2f, accelProgress);
            transform.position = Vector3.Lerp(startPos, targetPos, accelProgress);
            transform.Rotate(0, 0, 5 * Time.deltaTime);

            yield return null;
        }

        CameraShake.instance.Shake(0.1f, 0.1f);

        StartCoroutine (FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        flashImg.gameObject.SetActive(true);

        yield return new WaitForSeconds(flashTime);

        Color alpha = Color.white;

        while (alpha.a > 0)
        {
            alpha.a -= Time.deltaTime;
            flashImg.color = alpha;

            yield return null;
        }

        sprite.enabled = false;
        flashImg.gameObject.SetActive(false);

        yield return new WaitForSeconds(1);

        UIManager.instance.SetGameClearPanel();
    }
}