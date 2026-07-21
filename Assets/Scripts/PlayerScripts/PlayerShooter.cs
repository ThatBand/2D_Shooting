using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void UpgradePower(int value)
    {
        if (power >= maxPower)
            ScoreManager.instance.ScorePlus(300);

        power += value;
    }

    void Fire()
    {
        if (!Input.GetKey(KeyCode.Z))
            return;

        if (time < fireTime)
            return;

        switch (power)
        {
            case >= 0 and < 10:
                fireTime = 0.25f;
                GameObject bullet = Instantiate(bulletA, transform.position, Quaternion.identity);
                break;
            case >= 10 and < 25:
                fireTime = 0.175f;
                GameObject bulletL = Instantiate(bulletA, transform.position + Vector3.left * 0.2f, Quaternion.identity);
                GameObject bulletR = Instantiate(bulletA, transform.position + Vector3.right * 0.2f, Quaternion.identity);
                break;
            case >= 25:
                fireTime = 0.1f;
                GameObject bulletLL = Instantiate(bulletA, transform.position + Vector3.left * 0.35f, Quaternion.identity);
                GameObject bulletCC = Instantiate(bulletB, transform.position, Quaternion.identity);
                GameObject bulletRR = Instantiate(bulletA, transform.position + Vector3.right * 0.35f, Quaternion.identity);
                break;
        }

        time = 0;
    }
}