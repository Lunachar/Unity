using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private PlayerStats playerStats;
    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }


    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (playerStats.playerHealth > 0)
        {
            playerStats.playerHealth -= 10;
            Destroy(gameObject, 1f);
        }
    }
}

