using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject inventory;
    public GameObject fitting;
    private bool inventoryEnabled, fittingEnabled;
    public GameObject hpBar;

    private void Start()
    {
        //inventory
        inventory.SetActive(false);
        inventoryEnabled = false;
        fitting.SetActive(false);
        fittingEnabled = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            toggleInventory();
        }

        if (Input.GetButtonDown("Fitting"))
        {
            toggleFitting();
        }
    }

    public void disableAll()
    {
        //TODO
    }

    public void toggleInventory()
    {
        
        if (inventoryEnabled)
        {
            inventory.SetActive(false);
            hpBar.SetActive(true);

        }
        else
        {
            inventory.SetActive(true);
            hpBar.SetActive(false);
        }
        inventoryEnabled = !inventoryEnabled;
    }

    public void toggleFitting()
    {

        if (fittingEnabled)
        {
            fitting.SetActive(false);
            hpBar.SetActive(true);

        }
        else
        {
            fitting.SetActive(true);
            hpBar.SetActive(false);
        }
        fittingEnabled = !fittingEnabled;
    }

}