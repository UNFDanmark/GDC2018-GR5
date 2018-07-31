using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winnerscreen : MonoBehaviour {

    //public float yellowWinner;
    //public float redWinner;
    public FindWinner winner;
    public GameObject Yellow;
    public GameObject Red;

	// Use this for initialization
	void Start () {

        winner = GameObject.FindObjectOfType<FindWinner>();

        if (winner.winner == "Player1")
        {
            Yellow.SetActive(false);
            Red.SetActive(true);
        }
        else if (winner.winner == "Player2")
        {
            Red.SetActive(false);
            Yellow.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
