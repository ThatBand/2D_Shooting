using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("파워 설정 값")]
    public int power;
    public int maxPower;

    [Header("발사 속도 설정 값")]
    public float mainFireTime;
    public float subFireTime;
    public float induceFireTime;

    [Header("서브 총알 각도")]
    public float subBulletAngle;

    [Header("총알 프리팹")]
    public GameObject mainBullet;
    public GameObject subBullet;
    public GameObject induceBullet;

    private float mainTimer;
    private float subTimer;
    private float induceTimer;

    // Update is called once per frame
    void Update()
    {
        mainTimer += Time.deltaTime;
        subTimer += Time.deltaTime;
        induceTimer += Time.deltaTime;

        if (!Input.GetKey(KeyCode.Z))
            return;

        FireMain();
        SubFire();
        InduceFire();
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

    void FireMain()
    {
        if (mainTimer < mainFireTime)
            return;

        SoundManager.instance.PlayerMainShootSound();

        switch (power)
        {
            case >= 0 and < 10:
                mainFireTime = 0.25f;

                GameObject bullet = Instantiate(mainBullet, transform.position, Quaternion.identity);
                break;
            case >= 10 and < 25:
                mainFireTime = 0.2f;

                SoundManager.instance.PlayerMainShootSound();

                GameObject bulletMainLeft = Instantiate(mainBullet, transform.position + Vector3.left * 0.15f, Quaternion.identity);
                GameObject bulletMainRight = Instantiate(mainBullet, transform.position + Vector3.right * 0.15f, Quaternion.identity);
                break;
            case >= 25 and < 40:
                mainFireTime = 0.15f;

                SoundManager.instance.PlayerMainShootSound();

                GameObject bulletMainLeft2 = Instantiate(mainBullet, transform.position + Vector3.left * 0.15f, Quaternion.identity);
                GameObject bulletMainRight2 = Instantiate(mainBullet, transform.position + Vector3.right * 0.15f, Quaternion.identity);
                break;
            case >= 40:
                mainFireTime = 0.1f;

                SoundManager.instance.PlayerMainShootSound();

                GameObject bulletMainLeft3 = Instantiate(mainBullet, transform.position + Vector3.left * 0.15f, Quaternion.identity);
                GameObject bulletMainRight3 = Instantiate(mainBullet, transform.position + Vector3.right * 0.15f, Quaternion.identity);
                break;
        }

        mainTimer = 0;
    }

    void SubFire()
    {
        if (subTimer < subFireTime)
            return;

        switch (power)
        {
            case >= 20 and < 25:
                subFireTime = 0.5f;

                SoundManager.instance.PlayerSubShootSound();

                GameObject bulletSubLeft = Instantiate(subBullet, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                bulletSubLeft.transform.localRotation = Quaternion.Euler(0, 0, subBulletAngle);

                GameObject bulletSubRight = Instantiate(subBullet, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                bulletSubRight.transform.localRotation = Quaternion.Euler(0, 0, -subBulletAngle);
                break;
            case >= 25 and < 30:
                subFireTime = 0.35f;

                SoundManager.instance.PlayerSubShootSound();

                GameObject bulletSubLeft2 = Instantiate(subBullet, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                bulletSubLeft2.transform.localRotation = Quaternion.Euler(0, 0, subBulletAngle);

                GameObject bulletSubRight2 = Instantiate(subBullet, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                bulletSubRight2.transform.localRotation = Quaternion.Euler(0, 0, -subBulletAngle);
                break;
            case >= 30 and < 40:
                subFireTime = 0.2f;

                SoundManager.instance.PlayerSubShootSound();

                GameObject bulletSubLeft3 = Instantiate(subBullet, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                bulletSubLeft3.transform.localRotation = Quaternion.Euler(0, 0, subBulletAngle);

                GameObject bulletSubRight3= Instantiate(subBullet, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                bulletSubRight3.transform.localRotation = Quaternion.Euler(0, 0, -subBulletAngle);
                break;
            case >= 40:
                subFireTime = 0.175f;

                SoundManager.instance.PlayerSubShootSound();

                GameObject bulletSubLeft4 = Instantiate(subBullet, transform.position + Vector3.left * 0.3f, Quaternion.identity);
                bulletSubLeft4.transform.localRotation = Quaternion.Euler(0, 0, subBulletAngle);

                GameObject bulletSubRight4 = Instantiate(subBullet, transform.position + Vector3.right * 0.3f, Quaternion.identity);
                bulletSubRight4.transform.localRotation = Quaternion.Euler(0, 0, -subBulletAngle);
                break;
        }

        subTimer = 0;
    }

    void InduceFire()
    {
        if (induceTimer < induceFireTime)
            return;

        switch (power)
        {
            case >= 40:
                induceFireTime = 0.15f;
                SoundManager.instance.PlayerInduceShootSound();
                GameObject induceBulletLeft = Instantiate(induceBullet, transform.position + Vector3.left * 0.5f, Quaternion.identity);
                induceBulletLeft.transform.localRotation = Quaternion.Euler(0, 0, 20);

                GameObject induceBulletRight = Instantiate(induceBullet, transform.position + Vector3.right * 0.5f, Quaternion.identity);
                induceBulletRight.transform.localRotation = Quaternion.Euler(0, 0, -20);
                break;
        }

        
        induceTimer = 0;
    }
}