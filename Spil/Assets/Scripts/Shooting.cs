using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float missileSpeed;
    public Rigidbody Missile;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Input.GetKey("f")) {
            Move(missileSpeed);
        }
    }

    public void Move(float speed)
    {
        Missile.velocity = (Vector3.up * Missile.velocity.y) + (transform.up * speed);
    }


}
