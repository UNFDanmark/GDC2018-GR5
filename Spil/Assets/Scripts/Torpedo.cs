using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Torpedo : MonoBehaviour {

    public float missileSpeed;
    public float cooldown;
    public float lifeTime;
    public float explosionPower = 9001;
    public float explosionRadius = 5;
    public Rigidbody Missile;
    public string target = "player2";
    public AudioSource Hit;
    public AudioClip Boom;
    //public GameObject winner;

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
            Hit.Play();
            DontDestroyOnLoad(gameObject);
            GameObject.FindObjectOfType<FindWinner>().winner = "Player2";
            DontDestroyOnLoad(GameObject.FindObjectOfType<FindWinner>());
            Destroy(trigger.gameObject);
            SceneManager.LoadScene("ResultScreen");

        }
    }

    // Update is called once per frame
    void Update ()
    {
        transform.LookAt(transform.position + Missile.velocity);
    }
}
