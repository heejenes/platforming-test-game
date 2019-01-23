using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapple : MonoBehaviour {

	public Transform player;
	public Rigidbody body;
	float GIn;
	LineRenderer lineRenderer;
    public Collider farthest;
	float grappleSpeed;
	public float flyingSpeed;
	public float touchingSpeed;
    List<Collider> pegs;
	public bool touchingPeg = false;
	public bool touchingFarthestPeg = false;
	bool inRange;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
    }
	
	// Update is called once per frame
	void Update () {
		GIn = Input.GetAxis ("Grapple");

		//touchingPeg = false;
		//touchingFarthestPeg = false;

		transform.position = player.position;

		if (GIn == 0) {
			lineRenderer.SetPosition (0, player.position);
			lineRenderer.SetPosition (1, player.position);
			farthest = body.GetComponent<Collider> ();
		}
	}

	void OnTriggerStay(Collider things){

        if (GIn == 0)
        {
            if (things.tag == "Peg") //gets farthest of all in-range pegs
            {
                //float xDist = things.transform.position.x - player.position.x;
                float yDist = things.transform.position.y - player.position.y;
                //float xFarthestDist = farthest.transform.position.x - player.position.x;
                float yFarthestDist = farthest.transform.position.y - player.position.y;

                if (yDist > yFarthestDist)
                {
                    farthest = things;
                }
            }
        }

		else if (farthest == things) { // if input and !!in range!!, add force 
			//Debug.Log ("Input and Range for Grapple");
			float XSlope = farthest.transform.position.x - player.position.x;
			float YSlope = farthest.transform.position.y - player.position.y;
			lineRenderer.SetPosition (0, player.position);
			lineRenderer.SetPosition (1, farthest.transform.position);
			if (touchingFarthestPeg) {
				grappleSpeed = touchingSpeed;
			}
			else {
				grappleSpeed = flyingSpeed;
			}
			body.velocity = new Vector3 (XSlope * grappleSpeed * Time.deltaTime, YSlope * grappleSpeed * Time.deltaTime, 0);
		}
	}
}
