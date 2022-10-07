using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] Transform CurrentEnemy;
    [SerializeField] Transform Transform_PlayerBody;
    [SerializeField] private int minimalDistance = 5;
    [SerializeField] private float followSpeed = 3;
    [SerializeField] private float rotationSpeed = 3;

 
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private float shootingSpeedDelay = 1f;
    private float timer;

    enum MinionStates { LookPlayer, LookEnemy }
    MinionStates minionStates = MinionStates.LookPlayer;


    private void Awake()
    {
        Transform_PlayerBody = GameObject.Find("Player_Capsule").transform;
        
    }
    private void Start()
    {
        BulletSpawn = transform.Find("BulletSpawn");
    }
    private void FixedUpdate()
    {
        StateMachine();
        Follow(Transform_PlayerBody);
        CurrentEnemy = EnemyManager._Enemy_Nearest.transform;
    }


    private void StateMachine()
    {
        if (minionStates == MinionStates.LookPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Transform_PlayerBody.rotation, rotationSpeed * Time.deltaTime);

            if (EnemyManager._Enemy_Nearest != null)
            {
                minionStates = MinionStates.LookEnemy;
            }
        }
        else if (minionStates == MinionStates.LookEnemy)
        {
            transform.LookAt(EnemyManager._Enemy_Nearest.transform);

            timer += Time.deltaTime;
            if (timer > shootingSpeedDelay)
            {
                timer = 0;
                OnShoot();
            }

            if (EnemyManager._Enemy_Nearest == null)
            {
                minionStates = MinionStates.LookPlayer;
            }
        }
    }
    private void Follow(Transform target)
    {
        if ((Transform_PlayerBody.position - transform.position).magnitude >= minimalDistance)
        {
            Vector3 ObjA = Transform_PlayerBody.position;
            ObjA.y += 1.5f;
            transform.position = Vector3.Slerp(transform.position, ObjA, followSpeed / 10 * Time.deltaTime);
        }
    }
    private void OnShoot()
    {
        Instantiate(bullet, BulletSpawn.position, BulletSpawn.rotation);
    }
}
