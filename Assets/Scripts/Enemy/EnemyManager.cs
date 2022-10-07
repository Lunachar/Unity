using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    #region SINGLETONE
    public static EnemyManager instance { get; private set; }
    #endregion
    #region Monobehaviour
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
    }
    private void Update()
    {
        SearchNearestEnemy();
    }
    #endregion
    #region Variables
    public static Enemy _Enemy_Nearest;
    #endregion
    #region Functions (private)
    private void SearchNearestEnemy()
    {
        
    }
    #endregion
}
