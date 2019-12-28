using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject inventory;
    private bool inventoryEnabled;

    private void Start()
    {
        //inventory
        inventory.SetActive(false);
        inventoryEnabled = false; 
    }
    public void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            toggleInventory();
        }
    }

    public void toggleInventory()
    {
        
        if (inventoryEnabled)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
        inventoryEnabled = !inventoryEnabled;
    }

}