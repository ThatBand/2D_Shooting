using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public int power;
    public int maxPower;

    public float fireTime;

    public float subBulletAngle;
    private float time;

    public GameObject mainBullet;
    public GameObject subBullet;
    public GameObject induceBullet;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        Fire();
    }

    public void UpgradePower(int value)
    {
        if (power >= maxPower)
        {
            ScoreManager.instance.ScorePlus(300);
            UIManager.instance.UpdateMaxPower();
        }
            

        power += value;
        UIManager.instance.UpdatePower(power);
    }

    void Fire()
    {
        if (!Input.GetKey(KeyCode.Z))
            return;

        if (time < fireTime)
            return;

        //SoundManager.instance.PlayerShootSound();
        switch (power)
        {
            case >= 0 and < 10:
                fireTime = 0.2f;
                GameObject bullet = Instantiate(mainBullet, transform.position, Quaternion.identity);
                break;
            case >= 10 and < 25:
                fireTime = 0.15f;
                GameObject bulletMainLeft = Instantiate(mainBullet, transform.position + Vector3.left * 0.15f, Quaternion.identity);
                GameObject bulletMainRight = Instantiate(mainBullet, transform.position + Vector3.right * 0.15f, Quaternion.identity);
                break;
            case >= 25:
                fireTime = 0.08f;
                GameObject bulletMainLeft2 = Instantiate(mainBullet, transform.position + Vector3.left * 0.15f, Quaternion.identity);
                GameObject bulletMainRight2 = Instantiate(mainBullet, transform.position + Vector3.right * 0.15f, Quaternion.identity);

                GameObject bulletSubLeft = Instantiate(subBullet, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                bulletSubLeft.transform.localRotation = Quaternion.Euler(0, 0, subBulletAngle);

                GameObject bulletSubRight = Instantiate(subBullet, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                bulletSubRight.transform.localRotation = Quaternion.Euler(0, 0, -subBulletAngle);
                break;
        }

        time = 0;
    }
}