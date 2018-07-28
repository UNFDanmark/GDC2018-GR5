using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {

    public float missileSpeed;
    public float cooldown;
    public float lifeTime;
    public float explosionPower = 9001;
    public float explosionRadius = 5;
    public Rigidbody Missile;
    public string target = "player2";

    void Awake()
    {
        Missile = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start ()
    {
        Missile.velocity = transform.forward * missileSpeed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag(target) != trigger)
        {
            Destroy(trigger.gameObject);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        transform.LookAt(transform.position + Missile.velocity);
    }
}
