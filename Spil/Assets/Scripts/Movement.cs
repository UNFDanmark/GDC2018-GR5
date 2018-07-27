using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    public string playerControlForwardBackwards;
    public string playerControlLeftRight;
    public Rigidbody Submarine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, -rotationSpeed * Input.GetAxis(playerControlForwardBackwards) * Time.deltaTime, Space.Self);
    }

    private void FixedUpdate()
    {
        Move(moveSpeed * Input.GetAxis(playerControlLeftRight));
    }

    public void Move(float speed) {
        Submarine.velocity = (Vector3.up * Submarine.velocity.y) + (transform.up * speed);
    }

}
