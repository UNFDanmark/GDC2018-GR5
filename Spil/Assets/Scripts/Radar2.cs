using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar2 : MonoBehaviour
{

    public float radius;
    public float refreshTime = 2;
    public float timeOfLastScan;
    public Animator anim;
    public Rigidbody myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("[2]") && Time.time - timeOfLastScan >= refreshTime)
        {
            anim.SetFloat("Base", 1f);
        }
        else
        {
            anim.SetFloat("Base", 0f);
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Player1"))
        {
            print("Enemy found!");
        }
    }
}
