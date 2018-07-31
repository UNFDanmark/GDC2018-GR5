using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

    public float startTime;

    // Use this for initialization
    void Awake () {
        print("Start");
        startTime = Time.unscaledTime;
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.unscaledTime - startTime >= 5)
        {
            Time.timeScale = 1;
            print("Time" + Time.unscaledTime + "starttime" + startTime);
            Destroy(gameObject);
        }
	}

}
