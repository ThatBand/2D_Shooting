using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    public GameObject text;
    public bool isWeakness;

    public EnemyHealth bossHealth;

    public void ReceiveDamage(float baseDmg)
    {
        if (bossHealth.isInvin)
            return;

        Vector3 textPos = transform.position + new Vector3(2.5f, 1f, 0);

        GameObject textClone = Instantiate(text, textPos, Quaternion.identity);
        
        DamageText tmp = textClone.GetComponent<DamageText>();

        if (isWeakness)
        {
            bossHealth.TakeDamage(baseDmg * 2);
            SoundManager.instance.BossCriticalHitSound();

            tmp.Setup(baseDmg * 2, true);

            Debug.Log("약점 히트! 크리티컬 데미지 두 배!");
        }

        else
        {
            bossHealth.TakeDamage(baseDmg);
            SoundManager.instance.BossNormalHitSound();

            tmp.Setup(baseDmg, false);
            
            Debug.Log("보스 히트! 기본 데미지");
        }
    }
}
