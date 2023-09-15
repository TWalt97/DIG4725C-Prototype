using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LionController : MonoBehaviour
{
    private NavMeshAgent agent;

    private enum State
    {
        Walking,
        Attacking
    }

    private State state;

    public float chargeSpeed;

    public EnemyStats lionStats;
    private float health;
    
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = lionStats.speed;
        health = lionStats.health;
        state = State.Walking;
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player)
        {
            if (Vector3.Distance(agent.transform.position, player.transform.position) > lionStats.chargeRange && state == State.Walking)
            {
            agent.SetDestination(player.transform.position);
            }
            else if (state == State.Walking)
            {
            agent.enabled = false;
            state = State.Attacking;
            StartCoroutine(ChargeAttack());
            }
        }
        
    }

    private IEnumerator ChargeAttack()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(gameObject.transform.forward * chargeSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(1.0f);
        rb.velocity = new Vector3(0, 0, 0);
        state = State.Walking;
        agent.enabled = true;
        yield return null;
    }
}
