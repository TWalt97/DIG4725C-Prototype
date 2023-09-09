using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LionController : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;

    private enum State {
        Walking,
        Circling,
        Attacking
    }

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Walking;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) 
        {
            case State.Circling:
                break;
        }
        if (Vector3.Distance(agent.transform.position, player.transform.position) > 8.0f)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.SetDestination(agent.transform.position);
        }
    }
}
