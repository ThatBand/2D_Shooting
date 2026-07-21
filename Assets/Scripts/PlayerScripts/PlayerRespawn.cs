using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PlayerHealth))]
public class PlayerRespawn : MonoBehaviour
{
    private void Start()
    {
        GetComponent<PlayerHealth>().OnDamaged += RespawnPlayer;
    }

    public void RespawnPlayer()
    {
        transform.position = new Vector3(0, -3.5f, 0);
    }
}
