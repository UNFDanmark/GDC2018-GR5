using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchScene : MonoBehaviour {

    public Color        targetPlayerColor;          // The target color of the player.
    public float        animationSpeed;             // The Speed in units per sec.
    public float        targetDepth;                // The target depth of the object after the animation.
    public float        startTime;
    public Renderer     playerRenderer;

    public Renderer     bottom;
    public Renderer     propeller;
    public Renderer     tower;

    public Transform    tranform;

    Color targetBottomColor;
    Color targetPropellerColor;
    Color targetTowerColor;

    public GameObject uBoat;
    private bool hidden = false;

    // Use this for initialization
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        tranform = GetComponent<Transform>();
        startTime = Time.time;
        Color targetBottomColor = new Color(bottom.material.color.r, bottom.material.color.b, bottom.material.color.g, 0);
        Color targetPropellerColor = new Color(propeller.material.color.r, propeller.material.color.b, propeller.material.color.g, 0);
        Color targetTowerColor = new Color(tower.material.color.r, tower.material.color.b, tower.material.color.g, 0);
    }
        
	// Update is called once per frame
	void Update () {

            // The target position is equal to the current x and z position but at another depth
            Vector3 targetPosition = new Vector3(tranform.position.x, targetDepth, transform.position.z);

            // The step size is equal to speed times frame time.
            float steps = animationSpeed * Time.deltaTime;

            // Move our currentPosition a step closer to the targetPosition.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, steps);

            if (Time.time - startTime <= 1.5)
            {
                // Move our currentColor a step closer to the targetColor
                bottom.material.color =         Color.Lerp(bottom.material.color, targetBottomColor, Time.time / animationSpeed * 2);
                propeller.material.color =      Color.Lerp(propeller.material.color, targetPropellerColor, Time.time / animationSpeed * 2);
                tower.material.color =          Color.Lerp(tower.material.color, targetTowerColor, Time.time / animationSpeed * 2);
                // make gameobjekt meshrenderer false.
            }
            else if (!hidden)
            {
                uBoat.SetActive(false);
                bottom.material.color = Color.white;
                propeller.material.color = Color.white;
                tower.material.color = Color.white;
                hidden = true;
            }
    }

}
