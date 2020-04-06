using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderBehaviour : MonoBehaviour
{
    NavMeshAgent agent;
    Transform playerPosition;
    MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rend = GetComponent<MeshRenderer>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPosition.position);

        if(rend.isVisible){
            agent.speed = 0;
        }
        else{
            agent.speed = 1.5f;
        }
    }
}
