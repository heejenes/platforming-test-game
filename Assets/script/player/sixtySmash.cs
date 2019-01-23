using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sixtySmash : MonoBehaviour {
	
	public float AC;
	float tempTimeCooldown = 0f;
	float tempTimeChargeup = 0f;
	//float charge;
	bool charging = false;
	Collider boxCol;
	public bool smashing = false;
	public float chargeMoveSpeed;
	public float maxChargeupTime;
	public float cooldownTime;
	public float smashSpeed;
	public Rigidbody body;
	public Transform player;

	// Use this for initialization
	void Start () {
		boxCol = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + new Vector3 (0f, -0.6f, 0f);
		AC = Input.GetAxis ("smashAttack");

		if (AC > 0 & Time.time - tempTimeCooldown > cooldownTime) { //if input, start charging attack
			charging = true;
			body.velocity = new Vector3 (body.velocity.x * chargeMoveSpeed, 3, 0); //start going up
			//charge = Time.time - tempTimeChargeup;

		}
		//if input was let go or max charge was reached,
		if ((charging & AC == 0) | Time.time - tempTimeChargeup > maxChargeupTime & AC > 0) { 
			tempTimeCooldown = Time.time; //set timer
			tempTimeChargeup = Time.time; //reset timer
			charging = false; //reset "charging"
			smashing = true;
		}
		if (AC == 0) { //if no input, continue resetting timer
			tempTimeChargeup = Time.time; //reset timer
		}
		if (smashing) { //if smash, SMASH
			body.velocity = new Vector3 (0, -smashSpeed, 0);
		}
		boxCol.enabled = smashing;
	}
	void OnTriggerEnter (Collider things) {
		if (things.tag != "Character" & things.tag != "ABLift" & things.tag != "Grapple"){
			Debug.Log (things.tag);
			Debug.Log ("is no longer smashing");
			smashing = false;
		}
	}
}
