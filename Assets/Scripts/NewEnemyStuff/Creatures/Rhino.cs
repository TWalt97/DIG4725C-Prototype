using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhino : NotBossAI
{
    public override IEnumerator Attack()
    {
        Debug.Log("This is the rhino script!");
        agent.enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        rb.AddForce(gameObject.transform.forward * 20, ForceMode.Impulse);
        yield return new WaitForSeconds(1.0f);
        rb.velocity = new Vector3(0, 0, 0);
        agent.enabled = true;
        yield return null;
    }
}
