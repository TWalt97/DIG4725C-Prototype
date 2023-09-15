using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject lionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            GameObject easyLionEnemy = GameObject.Instantiate(lionPrefab, Vector3.up, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GameObject mediumLionEnemy = GameObject.Instantiate(lionPrefab, Vector3.up, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GameObject hardLionEnemy = GameObject.Instantiate(lionPrefab, Vector3.up, Quaternion.identity);
        }
    }
}
