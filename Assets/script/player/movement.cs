using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//puddles of paint on ground and when stepped on, changes the colors you and character can see and turns rest to greyscale. 
//colors are picked so some objects are invisible when on certain colors. - for a puzzle part of game -

public class movement : MonoBehaviour {

	float YIn;
	float XIn;
	float ZIn;
	float AAIn;
	//float ABIn;
	float GIn;
	public float speed;
	public float jumpSpeed;
	public Rigidbody body;
	public float jumpTime;
	public bool canJump = false;
	float tempTime;
	float tempTimeAA = 0f;
	public bool grounded;
	public bool doubleJump = false;
	public bool doubleJumped = false;
	public Rigidbody bullet;
	public float bulletSpeed;
	Rigidbody clone;
	float facingRight = 1.1f;
	public float attackSpeed = 0f;

	void Start () {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		YIn = Input.GetAxis ("YAxis");
		XIn = Input.GetAxis ("XAxis");
		AAIn = Input.GetAxis ("shootAttack");
        GIn = Input.GetAxis("Grapple");

		if (XIn > 0) {
			facingRight = 1.1f;
		}
		if (XIn < 0) {
			facingRight = -1.1f;
		}
	
		if (canJump) { //if can jump

			if (Time.time - tempTime > jumpTime | YIn == 0) { //if time runs out or if no input, stop velocity
				canJump = false;
			}
			if (YIn > 0) { //if jump button is pressed, jump
				if (doubleJumped) { //if canDoubleJump, turn off doubleJump 
					doubleJump = false;

				}
				body.velocity = new Vector3 (body.velocity.x, jumpSpeed* YIn, body.velocity.z); 

			}
		}
		if (YIn == 0) {	
			if (grounded) { //if on ground and no press, let jump and refresh timer
				canJump = true;
				doubleJump = true;
				doubleJumped = false;
				tempTime = Time.time;
			}
			else if (doubleJump) { //if doublejump and no press, let jump and refresh timer
				canJump = true;
				doubleJumped = true;
				tempTime = Time.time;
			}
		}

		grounded = false;
		if (AAIn > 0 & Time.time - tempTimeAA > attackSpeed){
			shoot();
		}

        //////////////////////////////////////////////////////////////////\/\/\///\/\/\/

        if (canX(GIn)) {
            body.velocity = new Vector3(XIn * speed, body.velocity.y, 0);
        }
	}
	void OnCollisionStay(Collision thing){
		for (int i = 0; i < thing.contacts.Length; i++){
			if (thing.contacts[i].point.y < transform.position.y){
				grounded = true;
			}
		}
	}
	void shoot() { //shoot, then start timer.
		clone = Instantiate (bullet, transform.position + new Vector3 (facingRight, 0, 0), transform.rotation);
		clone.velocity = new Vector3 (facingRight * bulletSpeed, 0, 0);
		tempTimeAA = Time.time;
	}
    bool canX(float a) {
        if (a == 0) {
            return true;
        }
        else {
            return false;
        }
    }
	/*void OnTriggerStay(ABRange things){
		if (ABIn > 0 & things.tag == "Enemy") { //if attack input and it enemy
			things.attachedRigidbody.velocity = new Vector3 (0, 5, 0);
		}
	}*/
	/*void OnTriggerStay(Collider things){
		if (GIn > 0 & things.tag == "Peg") { // if input and in range, add force 
			float XSlope = things.transform.position.x - transform.position.x;
			float YSlope = things.transform.position.y - transform.position.y;
			lineRenderer.SetPosition (0, transform.position);
			lineRenderer.SetPosition (1, things.transform.position);
			body.velocity = new Vector3 (body.velocity.x, 0, body.velocity.z); //add force of wind later
			body.AddForce (XSlope * grappleSpeed * Time.deltaTime, YSlope * grappleSpeed * Time.deltaTime, body.velocity.z);
		}
	}*/
}
	