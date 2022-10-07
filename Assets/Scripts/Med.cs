using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Med : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (playerStats.playerHealth < 100)
        {
            playerStats.playerHealth = 100;
            Destroy(gameObject, 1f);
        }
    }
}