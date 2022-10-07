using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int playerHealth = 100;
    [SerializeField] public int playerAmmo = 100;
    [SerializeField] public bool playerKey = false;

    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {
            Time.timeScale = 0;
            Debug.Log("Игра окончена");
            ChangeScene(0);
            
        }

    }
        public void ChangeScene(int _sceneNumber)
        {
            SceneManager.LoadScene(_sceneNumber); 
    }

}
