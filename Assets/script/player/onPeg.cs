using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onPeg : MonoBehaviour {

	public GameObject grappleCol;
	//public bool isFarthest = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (GetComponent<Collider>() == grappleCol.GetComponent<grapple>().farthest) {
			isFarthest = true;
		}
		else {
			isFarthest = false;
		}*/
	} 
	//when sitting on a peg but going to another peg, you are still slowed even you arent touchiong targetPeg
	//figure out way to turn touchingPeg off
	
	void OnCollisionEnter(Collision thing) {		//when touch, make the character become a sphere without gravity
		if (thing.transform.tag == "Character") {	//so he can easily move around the peg while still touching it
			Debug.Log ("touching peg");
			grappleCol.GetComponent<grapple>().touchingPeg = true;
			/*if (isFarthest) {
				grappleCol.GetComponent<grapple>().touchingFarthestPeg = true;
			}*/
			//else {grappleCol.GetComponent<grapple>().touchingFarthestPeg = false;}
		}
	}
	void OnCollisionExit(Collision thing) {
		if (thing.transform.tag == "Character") {
			grappleCol.GetComponent<grapple>().touchingPeg = false;
			/*if (isFarthest) {
				grappleCol.GetComponent<grapple>().touchingFarthestPeg = false;
			}*/
		}
	}
}
