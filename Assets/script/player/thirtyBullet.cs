using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirtyBullet : MonoBehaviour {

	public float travelTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, travelTime);
	}
	void OnTriggerEnter (Collider other){
		if (other.transform.tag != "Character" & other.transform.tag != "ABLift" & other.transform.tag != "Grapple") {
			Destroy (gameObject, 0);
		} 
	}
}
