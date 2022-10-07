using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavNPC_Controller : MonoBehaviour
{
    [SerializeField] Transform[] Transforms_PathPoints = new Transform[3];
    NavMeshAgent NpcAgent;
    int randomNumber;

    private void Awake()
    {
        NpcAgent = GetComponent<NavMeshAgent>();
      
    }
    private void Update()
    {
        if (NpcAgent.remainingDistance < 0.05f)
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        randomNumber = Random.Range(0,3);
        NpcAgent.SetDestination(Transforms_PathPoints[randomNumber].position);
    }
}
