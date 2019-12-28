using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleBase : MonoBehaviour
{
    public int mass;
    public int crew;
    public int thrust;
    public int shieldHP;
    public int armorHP;
    public int hullHP;
    public int energyCost;
    public int cost;
    public List<GameObject> hardpoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        updateStats();
    }

    public void populateHardpoint(Object tur, int pos)
    {
        Debug.Log(hardpoints[pos].transform.position);
        GameObject newTur = Instantiate(tur, hardpoints[pos].transform.position, hardpoints[pos].transform.rotation, hardpoints[pos].transform.parent) as GameObject;
        if (hardpoints[pos] == null)
            hardpoints.Insert(pos, newTur);
        newTur.transform.parent = hardpoints[pos].transform.parent;
        GameObject.DestroyImmediate(hardpoints[pos]);
        hardpoints[pos] = newTur;
    }

    public void updateStats()
    {
        foreach (Transform child in transform)
        {
            ModuleBase modScript = child.GetComponent<ModuleBase>();
            if (modScript)
            {
                this.mass += modScript.mass;
                this.crew += modScript.crew;
                this.thrust += modScript.thrust;
                this.energyCost += modScript.energyCost;
                this.cost += modScript.cost;
            }
        }

    }
}
