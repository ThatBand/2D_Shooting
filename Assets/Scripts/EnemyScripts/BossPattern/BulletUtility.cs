using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUtility
{
    public static void SetRandomType(EnemyBullet eBullet, float red, float blue, float yellow)
    {
        float total = red + blue + yellow;
        float randNum = Random.Range(0f, total);

        if (randNum < red)
            eBullet.Setup(EnemyBullet.bulletType.red);

        else if (randNum < red + blue)
            eBullet.Setup(EnemyBullet.bulletType.blue);

        else
            eBullet.Setup(EnemyBullet.bulletType.yellow);
    }
}
