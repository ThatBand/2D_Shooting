using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    //빨간색: 피하기만 해야함
    //파란색: 부딪히면 점수 획득
    //노란색: 부수면 플레이어 파워 증가
    public enum bulletType { red, blue, yellow };
    public bulletType type;

    public float bulletHealth;
    public int blueBulletScore;

    public SpriteRenderer sprite;

    public GameObject scoreText;

    protected override void Start()
    {
        base.Start();

        bulletHealth = bulletData.health;
    }

    public void Setup(bulletType newType)
    {
        type = newType;

        switch (type)
        {
            case bulletType.red:
                sprite.color = Color.red;
                gameObject.layer = LayerMask.NameToLayer("RedBullet");
                break;
            case bulletType.blue:
                sprite.color = Color.blue;
                gameObject.layer = LayerMask.NameToLayer("BlueBullet");
                break;
            case bulletType.yellow:
                sprite.color = Color.yellow;
                gameObject.layer = LayerMask.NameToLayer("YellowBullet");
                break;
        }
    }

    public void EnemyBulletDamaged(float dmg)
    {
        if (type != bulletType.yellow)
            return;

        bulletHealth -= dmg;

        StartCoroutine(ColorChange());

        if (bulletHealth <= 0)
        {
            
            Destroy(gameObject);
            
            GameManager.instance.playerShooter.UpgradePower(2);
        }
    }

    IEnumerator ColorChange()
    {
        Color curColor = sprite.color;

        sprite.color = Color.white;

        yield return new WaitForSeconds(0.1f);

        sprite.color = curColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CoreHit"))
        {
            Destroy(gameObject);

            if (type == bulletType.blue)
            {
                Debug.Log("파란색 탄막 흡수! 점수 + " + blueBulletScore);
                GameObject text = Instantiate(scoreText, transform.position, Quaternion.identity);
                if (text.TryGetComponent(out ScoreBulletText textSC))
                    textSC.Setup();

                ScoreManager.instance.ScorePlus(blueBulletScore);

                return;
            }

            if (collision.transform.position != null && collision.transform.parent.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage();
        }
    }
}
