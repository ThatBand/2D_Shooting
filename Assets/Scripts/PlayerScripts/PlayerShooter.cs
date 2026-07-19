using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public int power;
    public int maxPower;

    public float fireTime;
    private float time;

    public GameObject bulletA;
    public GameObject bulletB;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Fire();
    }

    public void UpgradePower()
    {
        if (power >= maxPower)
            ScoreManager.instance.ScorePlus(300);

        power++;
    }

    void Fire()
    {
        if (!Input.GetKey(KeyCode.Z))
            return;

        if (time < fireTime)
            return;

        switch (power)
        {
            case >= 0 and < 5:
                GameObject bullet = Instantiate(bulletA, transform.position, Quaternion.identity);
                break;
            case >= 5 and < 10:
                GameObject bulletL = Instantiate(bulletA, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                GameObject bulletR = Instantiate(bulletA, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case >= 10:
                GameObject bulletLL = Instantiate(bulletA, transform.position + Vector3.left * 0.35f, Quaternion.identity);
                GameObject bulletCC = Instantiate(bulletB, transform.position, Quaternion.identity);
                GameObject bulletRR = Instantiate(bulletA, transform.position + Vector3.right * 0.35f, Quaternion.identity);
                break;
        }

        time = 0;
    }
}