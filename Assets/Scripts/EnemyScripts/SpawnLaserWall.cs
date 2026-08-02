using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaserWall : MonoBehaviour
{
    public GameObject laserWall;

    private LaserWall wallSC;
    public bool isFinish;

    private void Start()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y + 2);
        GameObject wall = Instantiate(laserWall, pos, Quaternion.identity);

        wallSC = wall.GetComponent<LaserWall>();
    }

    private void Update()
    {
        if (wallSC != null && wallSC.isFinish == true)
            this.isFinish = true;
    }
}
