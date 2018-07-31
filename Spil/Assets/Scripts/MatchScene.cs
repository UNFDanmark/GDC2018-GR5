using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchScene : MonoBehaviour {

    public Color    targetPlayerColor;          // The target color of the player.
    public float    animationSpeed;             // The Speed in units per sec.
    public float    targetDepth;                // The target depth of the object after the animation.
    public float startTime;
    public Renderer playerRenderer;
    public Transform tranform;
    

    // Use this for initialization
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        tranform = GetComponent<Transform>();
        startTime = Time.time;
    }
        
	// Update is called once per frame
	void Update () {
        // The target position is equal to the current x and z position but at another depth
        Vector3 targetPosition = new Vector3(tranform.position.x, targetDepth, transform.position.z);

        // The step size is equal to speed times frame time.
        float steps = animationSpeed * Time.deltaTime;

        // Move our currentPosition a step closer to the targetPosition.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, steps);

        if (Time.time - startTime <= 1.5) {
            // Move our currentColor a step closer to the targetColor
            playerRenderer.material.color = Color.Lerp(playerRenderer.material.color, targetPlayerColor, Time.time / animationSpeed * 2);
        }


        
    }
    /*
    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }
    */

}
