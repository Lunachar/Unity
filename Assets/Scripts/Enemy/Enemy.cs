using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] private Transform Target;
    [SerializeField] private float viewDistance = 10;
    [SerializeField] private int rotationSpeed = 10;
    public float distanceToPlayer;

    [Header("Shoot Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform BulletSpawn;
    [SerializeField] private float shootingSpeedDelay = 1f;
    private float timer;
    
    enum StateVision { NotVisibilityTarget, VisibilityTarget }
    StateVision stateVision = StateVision.NotVisibilityTarget;
    



    private void Start()
    {
        BulletSpawn = transform.Find("EnemyBulletSpawn");
        Target = GameObject.Find("Player").transform;
    }
    private void FixedUpdate()
    {
        StateMachine();
    }


    private void StateMachine()
    {
        Debug.Log(stateVision);
        switch (stateVision)
        {
            case StateVision.NotVisibilityTarget:
                

                distanceToPlayer = (Target.position - transform.position).magnitude;

                if (distanceToPlayer < viewDistance)
                {
                    EnemyManager._Enemy_Nearest = this;
                    stateVision = StateVision.VisibilityTarget;
                }
                break;


            case StateVision.VisibilityTarget:
                {
                    Vector3 relativePos = Target.position - transform.position;
                    Vector3 rot = Quaternion.LookRotation(relativePos).eulerAngles;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot.y, 0), rotationSpeed * Time.deltaTime);

                    distanceToPlayer = (Target.position - transform.position).magnitude;

                    timer += Time.deltaTime;
                    if (timer > shootingSpeedDelay)
                    {
                        timer = 0;
                        OnShoot();
                    }

                    if (distanceToPlayer > viewDistance)
                    {
                        EnemyManager._Enemy_Nearest = null;
                        stateVision = StateVision.NotVisibilityTarget;
                    }
                }
                break;
        }
    }
    private void OnShoot()
    {
        Instantiate(bullet, BulletSpawn.position, BulletSpawn.rotation);
    }
}
