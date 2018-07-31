using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float missileSpeed;
    public float reloadTime = 2;
    public float timeOfLastShot;
    public AudioSource TorpedoShot;
    public AudioClip Launch;
    public GameObject missilePrefab;

    // Use this for initialization
    void Start ()
    {
        timeOfLastShot = -reloadTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKeyDown("f") && Time.time - timeOfLastShot >= reloadTime)
        {
            Shoot();
            TorpedoShot.PlayOneShot(Launch);
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
