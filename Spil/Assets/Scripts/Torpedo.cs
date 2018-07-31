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
            GameObject.FindObjectOfType<FindWinner>().winner = "Player1";
            DontDestroyOnLoad(GameObject.FindObjectOfType<FindWinner>());
            SceneManager.LoadScene("ResultScreen");
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
