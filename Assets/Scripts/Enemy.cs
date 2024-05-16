using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target; // Corrected spelling of SerializeField

    UnityEngine.AI.NavMeshAgent agent;

    //public isPlayerSeat = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) // Check if target is not null
        {
            agent.SetDestination(target.position);
        }
    }
}
