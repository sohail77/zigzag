﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;
	[SerializeField]
	private float speed;
	bool started;
	bool gameover;
	Rigidbody rb;

	void Awake(){
	
		rb = GetComponent<Rigidbody> ();
	}



	// Use this for initialization
	void Start () {

		started = false;
		gameover = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
		
			if (Input.GetMouseButtonDown (0)) {
			
				rb.velocity = new Vector3 (speed, 0, 0);
				started = true;

				GameManager.instance.StartGame ();
			}
		}

		if(!Physics.Raycast(transform.position,Vector3.down,1f)){
		
			gameover=true;
			rb.velocity = new Vector3 (0, -25f, 0);

			Camera.main.GetComponent<cameraFollow> ().gameover = true;
			GameManager.instance.StopGame ();
		}

		if (Input.GetMouseButtonDown (0) && !gameover) {
			switchDirection ();
		}
	}

	void switchDirection(){
	
		if (rb.velocity.z > 0) {
		
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
		
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "diamond") {

			GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			Destroy (part, 1f);
		}

	}

}
