using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace enemy.hitPoints {
	public class health : MonoBehaviour {

		public int maxHp;
		public float curHp;
		float ABIn;

		// Use this for initialization
		void Start () {
			curHp = maxHp;
		}

		// Update is called once per frame
		void Update () {
			ABIn = Input.GetAxis ("liftAttack");
			if (curHp < 1) {
				death ();
			}
		}
		
		void OnTriggerEnter(Collider things){
			if (things.gameObject.tag == "AAThirtyBullet") {
				curHp -= 30f;
				Debug.Log ("health is: " + curHp + "thirty");
			}
			if (things.gameObject.tag == "ABLift" & ABIn > 0) { // move to oncollisionstay.
				curHp -= 10f;
				Debug.Log ("health is: " + curHp + "AB");
			}
			if (things.gameObject.tag == "ACSmash") {
				curHp -= 60f;
				Debug.Log ("health is: " + curHp + "AC");
			}
		}
		/*void OnCollisionEnter (Collision things){
			if (things.relativeVelocity.magnitude > 15f) {
				curHp -= things.relativeVelocity.magnitude / 5;
				Debug.Log ("health is: " + curHp + "from fall");
			}
		}*/
		void death(){
			Destroy (gameObject, 0);
		}
	}
}
