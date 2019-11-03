using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration_amount = 1f;
    public float rotation_speed = 1f;
    public int mass, crew, thrust, energy, cost;

    private int boostCd = 0;
    private GameObject hull, left, right;
    private Rigidbody2D rb;
    private ModuleBase hullStats, leftStats, rightStats;
    // Use this for initialization
    void Start()
    {
        hull = this.transform.Find("hull_prefab").gameObject;
        left = this.transform.Find("left_prefab").gameObject;
        right = this.transform.Find("right_prefab").gameObject;
        rb = GetComponent<Rigidbody2D>();
        hullStats = hull.GetComponent<ModuleBase>();
        leftStats = left.GetComponent<ModuleBase>();
        rightStats = right.GetComponent<ModuleBase>();
        mass = hullStats.mass + leftStats.mass + rightStats.mass;
        crew = hullStats.crew + leftStats.crew + rightStats.crew;
        thrust = hullStats.thrust + leftStats.thrust + rightStats.thrust;
        energy = hullStats.energyCost + leftStats.energyCost + rightStats.energyCost;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject newHull = (GameObject)Instantiate(Resources.Load("Prefabs/hull2_prefab"), hull.transform.parent);
            newHull.transform.parent = hull.transform.parent;
            GameObject.DestroyImmediate(hull);
            hull = newHull;
            hull.transform.name = "hull_prefab";
            Object newtur = Resources.Load("Prefabs/t_small");
            hull.GetComponent<ModuleBase>().populateHardpoint(newtur, 0);
            hull.GetComponent<ModuleBase>().populateHardpoint(newtur, 1);
        }
        // rb.AddForce((-transform.up) * acceleration_amount * Time.deltaTime);
        rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration_amount * Time.deltaTime);
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * acceleration_amount * Time.deltaTime);
        rb.AddTorque(-Input.GetAxis("Yaw") * 100 * Time.deltaTime);
        if (Input.GetButton("Break"))
        {
           rb.angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * 0.06f * Time.deltaTime);
           rb.velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * 0.06f * Time.deltaTime);
        }
        if (Input.GetButton("Reset"))
        {
            transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if (Input.GetButton("Boost"))
        {
            if (boostCd > 0)
            {
                boostCd--;
            }
            else
            {
                rb.AddForce(transform.up * 250);
                boostCd = 60;
            }
        }


    }
}
