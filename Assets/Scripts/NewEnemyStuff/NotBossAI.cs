using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NotBossAI : Creature
{
    protected NavMeshAgent agent;

    private enum EnemyState
    {
        Idle,
        Moving,
        Attacking,
    }

    private EnemyState myState;

    public Coroutine currentBehavior;

    private float currentDistance;
    private GameObject player;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateBehavior(EnemyState.Moving);
    }

    private void Update()
    {
        currentDistance = Vector3.Distance(agent.transform.position, player.transform.position);
        if (currentDistance < 5f && myState != EnemyState.Attacking)
        {
            UpdateBehavior(EnemyState.Attacking);
            Debug.Log(myState);
        }
        else if (currentDistance > 5f && myState != EnemyState.Moving)
        {
            UpdateBehavior(EnemyState.Moving);
            Debug.Log(myState);
        }
    }

    public virtual IEnumerator Idle()
    {
        yield return null;
    }

    public virtual IEnumerator Walk()
    {
        agent.destination = player.transform.position;
        yield return null;
    }

    public virtual IEnumerator Attack()
    {
        agent.enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(gameObject.transform.forward * 20, ForceMode.Impulse);
        yield return new WaitForSeconds(1.0f);
        rb.velocity = new Vector3(0, 0, 0);
        agent.enabled = true;
        yield return null;
    }

    private void UpdateBehavior(EnemyState state)
    {
        myState = state;
        if (currentBehavior != null)
        {
            StopCoroutine(currentBehavior);
        }
        switch (myState)
        {
            case EnemyState.Moving:
                currentBehavior = StartCoroutine(Walk());
                break;
            case EnemyState.Attacking:
                currentBehavior = StartCoroutine(Attack());
                break;
        }
    }
}
