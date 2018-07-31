using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour {

    public bool             isTriggered = false;
    public float            animationStartTime;
    public float            animationEnd;
    public Animator         animatior;
    
    public float            timeOfContact;

    public GameObject       playerUboad;
    public GameObject       enemyUboad;

    public MeshRenderer     rendererPlayer;
    public MeshRenderer     rendererEnemy;
    public string           player;
    public string           enemy;
    public Color            colorPlayer;
    public Color            colorEnemy;

    public Color            colorPlayer1;
    public MeshRenderer     rendererPlayer1;

    public Color            colorPlayer2;
    public MeshRenderer     rendererPlayer2;

    public MeshRenderer     rendererSonar;

    public float            timeOfLastScan;
    public float            cooldown = 2;
    public string           scanControll;           // Button to press to start a sonar scan for enemy player.

    public DetectionScript  enemyDetectionScript;

    // Use this for initialization
    void Start () {
        rendererSonar.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        switch (scanControll) 
        {
            case "g":
                if (Input.GetKeyDown(scanControll) && Time.time - timeOfLastScan >= cooldown)
                {
                    rendererPlayer = rendererPlayer1;
                    rendererEnemy = rendererPlayer2;
                    player = "Player1";
                    enemy = "Player2";
                    colorPlayer = colorPlayer1;
                    colorEnemy = colorPlayer2;
                    startAnimation();
                }
                break;
            case "[2]":
                if (Input.GetKeyDown(scanControll) && Time.time - timeOfLastScan >= cooldown)
                {
                    rendererPlayer = rendererPlayer2;
                    rendererEnemy = rendererPlayer1;
                    player = "Player2";
                    enemy = "Player1";
                    colorPlayer = colorPlayer2;
                    colorEnemy = colorPlayer1;
                    startAnimation();
                }
                break;
        }      

        // Calles the holdAnimation function if isTriggered = true
        if (isTriggered == true)
        {
            print("isTriggered = true");
            holdAnimation();
        }
        else if (Time.time - animationStartTime >= 5)
        {
            print("isTriggered = false");
            rendererPlayer.material.color = new Color(colorPlayer.r, colorPlayer.g, colorPlayer.b, 0);
            playerUboad.SetActive(false);
            isTriggered = false;
        }
        
        // Calls the endAnimation function if the enemy issent scanned, after the duration of the cooldown.
        if (Time.time - animationStartTime >= cooldown)
        {
            endAnimation();
        }
    }

    // Starts the scanning animation.
    void startAnimation()
    {
        animationStartTime = Time.time;
        rendererSonar.enabled = true;
        rendererPlayer.material.color = new Color(colorPlayer.r, colorPlayer.g, colorPlayer.b, 255);
        playerUboad.SetActive(true);
        animatior.SetFloat("Base", 1f);
    }

    // Ends the scanning animation after a scan has been tryed and hides the player.
    void endAnimation()
    {
        animatior.SetFloat("Base", 0f);
        rendererSonar.enabled = false;
    }

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag(enemy) && !trigger.isTrigger)
        {
            print("Contact is made");
            timeOfContact = Time.time;
            enemyDetectionScript.timeOfContact = Time.time;
            rendererEnemy.material.color = new Color(colorEnemy.r, colorEnemy.g, colorEnemy.b, 255);
            enemyUboad.SetActive(true);
            isTriggered = true;
            enemyDetectionScript.isTriggered = true;
        }
    }

    // Holds both players endAnimation the duration of the cooldown (5 sec), when istriggered = true, then hides both players at the same time and sets isTriggered = false.
    void holdAnimation()
    {
        if (Time.time - timeOfContact >= 5)
        {
            print("holdAnimations");
            rendererPlayer.material.color = new Color(colorPlayer.r, colorPlayer.g, colorPlayer.b, 0);
            playerUboad.SetActive(false);
            isTriggered = false;
        }
    }
}
