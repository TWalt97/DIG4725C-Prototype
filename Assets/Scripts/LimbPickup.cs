using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbPickup : MonoBehaviour
{
    public float rotateSpeed;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

    void Start () 
    {
    posOffset = transform.position;
    }

    void Update()
    {
        transform.Rotate(rotateSpeed, 0, 0, Space.Self);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InventoryController inventoryController = other.GetComponent<InventoryController>();
            Destroy(gameObject);
        }
    }
}
