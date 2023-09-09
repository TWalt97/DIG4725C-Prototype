using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class LionController : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject player;

    private enum State
    {
        Walking,
        Attacking
    }

    private State state;

    public float chargeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Walking;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(agent.transform.position, player.transform.position) > 5.0f && state == State.Walking)
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
