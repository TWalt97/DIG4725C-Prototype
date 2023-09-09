using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnLimb : MonoBehaviour
{
    public LimbPickupData headData;
    public LimbPickupData armsData;
    public LimbPickupData legsData;

    private LimbPickupData limbPickupData;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            int randomValue = Random.Range(0, 4);

            if (randomValue == 0)
            {
                limbPickupData = headData;
            }
            else if (randomValue == 1)
            {
                limbPickupData = armsData;
            }
            else if (randomValue == 2)
            {
                limbPickupData = legsData;
            }

            GameObject limbPickup = Instantiate(limbPickupData.gameObject, Vector3.up, Quaternion.identity);
            limbPickup.name = limbPickupData.name;
        }
    }

    public void DropLimb()
    {
        int randomValue = Random.Range(0, 4);

            if (randomValue == 0)
            {
                limbPickupData = headData;
            }
            else if (randomValue == 1)
            {
                limbPickupData = armsData;
            }
            else if (randomValue == 2)
            {
                limbPickupData = legsData;
            }

        GameObject limbPickup = Instantiate(limbPickupData.gameObject, Vector3.up, Quaternion.identity);
        limbPickup.name = limbPickupData.name;
    }
}
