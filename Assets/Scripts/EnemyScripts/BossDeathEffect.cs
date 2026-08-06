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

    private PlayerMove playerMove;
    private PlayerShooter playerShooter;
    private BossPatternManager manager;
    private EnemyHit hit;

    private bool particleEnd;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameManager.instance.player.GetComponent<PlayerMove>();
        playerShooter = GameManager.instance.player.GetComponent<PlayerShooter>();
        hit = GetComponent<EnemyHit>();
        manager = GetComponent<BossPatternManager>();
    }

    public void BossDeath()
    {
        StartCoroutine(BossDeathRoutine());
    }

    IEnumerator BossDeathRoutine()
    {
        manager.StopBossPattern();

        GameManager.instance.player.GetComponentInChildren<Collider2D>().enabled = false;
        playerMove.enabled = false;
        playerShooter.enabled = false;
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
            CameraShake.instance.Shake(0.1f, 0.1f);
        }

        yield return new WaitForSeconds(2);
    }

    //IEnumerator BossCrash()
    //{
    //    while (transform.localScale != Vector3.one * 0.2f)
    //    {

    //    }
    //}

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

        flashImg.gameObject.SetActive(false);
    }
}