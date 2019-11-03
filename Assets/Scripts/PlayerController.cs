using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration_amount = 1f;
    public float rotation_speed = 1f;
    public GameObject hull, left, right;

    private int boostCd = 0;
    private int mass, crew, thrust, energy, cost;
    private Rigidbody2D rb;
    private ModuleBase hullStats, leftStats, rightStats;
    // Use this for initialization
    void Start()
    {
        hull = this.transform.GetChild(0).gameObject;
        left = this.transform.GetChild(1).gameObject;
        right = this.transform.GetChild(2).gameObject;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpriteRenderer sr = left.GetComponent<SpriteRenderer>();
            Sprite sp = Resources.Load<Sprite>("Sprites/Ships/Modules/leftB");
            sr.sprite = sp;

            Sprite spt = Resources.Load<Sprite>("Sprites/Ships/Turrets/Turret Large 1");
            GameObject tur = GameObject.Find("Turret Large 2");
            SpriteRenderer ts = tur.GetComponent<SpriteRenderer>();
            ts.sprite = spt;
            PlayerControlledTurret tscript = tur.GetComponent<PlayerControlledTurret>();
            tscript.barrel_hardpoints.RemoveAt(1);
            Destroy(tscript.barrel_hardpoints[1].gameObject);
        }
        if (Input.GetKey(KeyCode.W)) //CHANGE TO USE THE PRESETS
        {
            rb.AddForce(transform.up * acceleration_amount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce((-transform.up) * acceleration_amount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
        {
           rb.AddTorque(-rotation_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddTorque(rotation_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.C))
        {
           rb.angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * 0.06f * Time.deltaTime);
           rb.velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * 0.06f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddForce(transform.right * acceleration_amount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(-transform.right * acceleration_amount * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
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
