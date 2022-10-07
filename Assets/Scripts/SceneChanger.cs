using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private PlayerStats playerStats;
    private void Awake()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        playerStats.playerHealth = 100;
        Time.timeScale = 1;

    }
    public void ChangeScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
