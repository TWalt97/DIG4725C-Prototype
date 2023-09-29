using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NotBossAI : Creature
{
    private NavMeshAgent agent;

    private enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
    }

    private EnemyState myState;


    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        agent.destination = player.transform.position;
        UpdateBehavior(EnemyState.Moving);
    }

    public IEnumerator Idle()
    {
        yield return null;
    }

    public IEnumerator Walk()
    {
        yield return null;
    }

    public IEnumerator Attack()
    {
        yield return null;
    }

    private void UpdateBehavior(EnemyState state)
    {
        myState = state;
    }
}
