using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildAWall : MonoBehaviour {

    public Rigidbody Wall;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        showWall();
    }

    void showWall()
    {
        //meshrenderer = GetComponent<MeshRenderer>;
    }
}
