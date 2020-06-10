using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration_amount = 1f;
    public float rotation_speed = 1f;
    public int mass, crew, thrust, energy, cost;
    public float shieldHP = 0;
    public float armorHP = 0;
    public float hullHP = 0; 

    private int boostCd = 0;
    private GameObject hull, left, right;
    private Rigidbody2D rb;
    private ModuleBase hullStats, leftStats, rightStats;

    public PlayerState playerState;
    public GameObject hpm;
    private hpHandler hph;
    // Use this for initialization
    void Start()
    {
        hph = hpm.GetComponent<hpHandler>();
        hull = this.transform.Find("hull_prefab").gameObject;
        left = this.transform.Find("left_prefab").gameObject;
        right = this.transform.Find("right_prefab").gameObject;
        rb = GetComponent<Rigidbody2D>();
        hullStats = hull.GetComponent<ModuleBase>();
        leftStats = left.GetComponent<ModuleBase>();
        rightStats = right.GetComponent<ModuleBase>();
        mass = hullStats.mass + leftStats.mass + rightStats.mass;
        thrust = hullStats.thrust + leftStats.thrust + rightStats.thrust;
        energy = hullStats.energyCost + leftStats.energyCost + rightStats.energyCost;

        shieldHP = hullStats.shieldHP + leftStats.shieldHP + rightStats.shieldHP;
        armorHP = hullStats.armorHP + leftStats.armorHP + rightStats.armorHP;
        hullHP = hullStats.hullHP + leftStats.hullHP + rightStats.hullHP;
        updateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                hph.healShields(15);
            }
            else
            {
                hph.takeDamage(10);
            }
        }

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
            updateStats();
        }
        if (thrust < 1)
        {
            thrust = 1;
        }
        rb.AddForce(transform.up * Input.GetAxis("Vertical") * acceleration_amount * thrust * Time.deltaTime);
        rb.AddForce(transform.right * Input.GetAxis("Horizontal") * acceleration_amount * thrust * Time.deltaTime);
        rb.AddTorque(-Input.GetAxis("Yaw") * 100  * Time.deltaTime);
        if (Input.GetButton("Break"))
        {
           rb.angularVelocity = Mathf.Lerp(GetComponent<Rigidbody2D>().angularVelocity, 0, rotation_speed * thrust * 0.06f * Time.deltaTime);
           rb.velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, Vector2.zero, acceleration_amount * thrust * 0.06f * Time.deltaTime);
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

    public void updateStats()
    {
        mass = 0;
        crew = 0;
        thrust = 0;
        energy = 0;
        cost = 0;
        shieldHP = 0;
        armorHP = 0;
        hullHP = 0;
        foreach (Transform child in transform)
        {
            var mb = child.GetComponent<ModuleBase>();
            mass += mb.mass;
            thrust += mb.thrust;
            energy += mb.energyCost;
            cost += mb.cost;
            shieldHP += mb.shieldHP;
            armorHP += mb.armorHP;
            hullHP += mb.hullHP;
        }
        GetComponent<Rigidbody2D>().mass = this.mass;
        hph.updateStats(shieldHP, armorHP, hullHP);
    }

    public float getShield()
    {
        return shieldHP;
    }

    public float getArmor()
    {
        return armorHP;
    }

    public float getHull()
    {
        return hullHP;
    }

  //  public PlayerStatistics LocalCopyOfData;
  //  public bool IsSceneBeingLoaded = false;

    public void SaveData()
    {
     //   if (!Directory.Exists("Saves"))
     //       Directory.CreateDirectory("Saves");

     //   BinaryFormatter formatter = new BinaryFormatter();
     //   FileStream saveFile = File.Create("Saves/save.binary");

     //   LocalCopyOfData = PlayerState.Instance.localPlayerData;

     //   formatter.Serialize(saveFile, LocalCopyOfData);

     //   saveFile.Close();
    }

    public void LoadData()
    {
       // BinaryFormatter formatter = new BinaryFormatter();
      //  FileStream saveFile = File.Open("Saves/save.binary", FileMode.Open);

      //  LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(saveFile);

      //  saveFile.Close();
    }
}
