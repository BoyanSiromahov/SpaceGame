using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretConroller : MonoBehaviour
{

    public GameObject weapon_prefab;
    public List<GameObject> barrel_hardpoints = new List<GameObject>();
    public float turret_rotation_speed = 3f;
    public float shot_speed;
    int barrel_index = 0;
    public float fireRate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+90));

        if (Input.GetButtonDown("Fire"))
        {
            InvokeRepeating("Fire", 0, fireRate);
        }
        if (Input.GetButtonUp("Fire"))
        {
            CancelInvoke("Fire");
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Fire()
    {
        if (barrel_hardpoints != null)
        {
            barrel_index++; 
            if (barrel_index >= barrel_hardpoints.Count)
                barrel_index = 0;
            GameObject bullet = (GameObject)Instantiate(weapon_prefab, barrel_hardpoints[barrel_index].transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * shot_speed);
            bullet.GetComponent<Projectile>().firing_ship = transform.parent.gameObject;
        }
    }
}
