using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{

    public float missileSpeed;
    public float reloadTime = 2;
    public float timeOfLastShot;
    public GameObject missilePrefab;

    // Use this for initialization
    void Start()
    {
        timeOfLastShot = -reloadTime;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("[0]") && Time.time - timeOfLastShot >= reloadTime)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject Missile = Instantiate(missilePrefab);
        Missile.transform.position = transform.position;
        Missile.transform.rotation = transform.rotation;
        timeOfLastShot = Time.time;
    }


}

