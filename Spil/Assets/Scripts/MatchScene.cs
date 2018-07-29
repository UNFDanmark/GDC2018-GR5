using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchScene : MonoBehaviour {

    public Vector3  targetPosition;         // The target position of the object.
    public Color    currentColor;
    public Color    targetColor;            // The target color of the object.
    public float    animationSpeed;         // The Speed in units per sec.

    public Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // The step size is equal to speed times frame time.
        float steps = animationSpeed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, steps);

        float lerp = Mathf.PingPong(Time.time, animationSpeed) / animationSpeed;  // Det skal ikke være en pingpong effect, find en anden!
        rend.material.color = Color.Lerp(currentColor, targetColor, lerp);

    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
    }
}
