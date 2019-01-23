using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	public Transform player;
	float ABIn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ABIn = Input.GetAxis ("liftAttack");
		transform.position = player.position;
	}

	void OnTriggerStay(Collider things){
		if (ABIn > 0 & things.tag == "Enemy") { //if attack input and it enemy
			things.attachedRigidbody.velocity = new Vector3 (0, 5, 0);
		}
	}
}
