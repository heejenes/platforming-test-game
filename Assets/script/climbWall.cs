using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class climbWall : MonoBehaviour{

	/*GameObject player;
	public bool rightSide;
	float pushoff = 1.0f;
	float pushup = 1.0f;
	bool canClimb = false;
	float UpIn;

	// Use this for initialization
	void Start (){
		if (rightSide == false) {
			pushoff *= -1;
		} 
		player = GameObject.Find ("Character");
	}
	
	// Update is called once per frame
	void Update (){
		if (canClimb) {
			UpIn = Input.GetAxis ("YAxis");
			player.GetComponent<Rigidbody> ().AddForce (Physics.gravity * player.GetComponent<Rigidbody> ().mass / 10); //reduce gravity
			if (UpIn>0){
				player.GetComponent<Rigidbody> ().velocity = new Vector3 (pushoff, pushup, 0); //push off
			}
		}
	}
	void OnCollisionEnter (Collision collider){
		if (collider.gameObject == player){
			canClimb = true;
		}
	}
	void OnCollisionExit (Collision collider){
		if (collider.gameObject == player){
			canClimb = false;
		}
	}*/
}

