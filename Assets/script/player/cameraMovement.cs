using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public Transform characterPos;
	public float YOffset;
	public float ZOffset;
	float zoom;
	float verPan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		zoom = Input.GetAxis ("cameraZoom") * 1.5f;
		verPan = Input.GetAxis ("cameraPanVer") * 1.5f;

		//pos value means zoom in
		//neg value means zoom out
		
		transform.position = characterPos.position + new Vector3(0, YOffset += verPan * Time.deltaTime, ZOffset += zoom * Time.deltaTime);
	}
}
