using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar2 : MonoBehaviour
{

    public float radius;
    public float refreshTime = 2;
    public float timeOfLastScan;
    public Animator anim;

    public Rigidbody Submarine;

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
            /*
            foreach (AnimationState state in anim)
            {
                state.speed = 0.5F;
            }
           
                radarCheck();*/
        }
        else
        {
            anim.SetFloat("Base", 0f);
        }
    }

    public void radarCheck()
    {
        int i = 0;

        for (i = 0; i < 7; i++)
        {
            transform.localScale += new Vector3(i, 0f, i);
        }



        Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyCollider in nearbyColliders)
        {
            if (nearbyCollider.CompareTag("Player2"))
            {
                print("Enemy found!");
            }
        }
    }



}
