using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    private bool inventoryOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;
            if(inventoryOpen == true)
            {
                inventoryPanel.SetActive(true);
            }
            else if(inventoryOpen == false)
            {
                inventoryPanel.SetActive(false);
            }
        }
    }
}
