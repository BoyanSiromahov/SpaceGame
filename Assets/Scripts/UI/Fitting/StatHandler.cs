using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHandler : MonoBehaviour
{

    public GameObject shield;
    public GameObject armor;
    public GameObject hull;
    public GameObject mass;
    public GameObject energy;
    public GameObject thrust;
    public GameObject value;
    public GameObject player;
    PlayerController p;

    // Start is called before the first frame update
    void Start()
    {
        p = player.GetComponent<PlayerController>();
        updateStats();
    }

    void Update()
    {
        if (this.isActiveAndEnabled)
        {
            updateStats();
        }
        
    }

    public void updateStats()
    {
        shield.GetComponent<Text>().text = "Shield: " + p.shieldHP.ToString();
        armor.GetComponent<Text>().text = "Armor: " + p.armorHP.ToString();
        hull.GetComponent<Text>().text = "Hull: " + p.hullHP.ToString();
        mass.GetComponent<Text>().text = "Mass: " + p.mass.ToString();
        energy.GetComponent<Text>().text = "Shield: " + p.crew.ToString();
        thrust.GetComponent<Text>().text = "Shield: " + p.thrust.ToString();
        value.GetComponent<Text>().text = "Shield: " + p.cost.ToString();
    }
}
