using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    public string playerControlLeftRight;
    public string playerControlForwardBackwards;
    public Rigidbody Submarine;

	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotationSpeed * Input.GetAxis(playerControlLeftRight) * Time.deltaTime, 0, Space.Self);
    }

    private void FixedUpdate()
    {
        Move(moveSpeed * Input.GetAxis(playerControlForwardBackwards));
    }

    public void Move(float speed) {
        Submarine.velocity = (Vector3.forward * Submarine.velocity.y) + (transform.forward * speed);
    }

}