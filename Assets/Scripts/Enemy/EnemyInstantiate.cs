using System.Collections;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private EnemyInstantiate Enemy;
    [SerializeField] private Vector3 enemyPosition1 = new Vector3(-19, 0, -20);
    private EnemyInstantiate enemy;


    // Start is called before the first frame update
    void Start()
    {
        wait();
        enemy = Instantiate(Enemy, enemyPosition1, Quaternion.identity);
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(5);
    }


}
