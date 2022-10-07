using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerStats.playerKey = true;
        Destroy(gameObject, 0.2f);
        
    }
}