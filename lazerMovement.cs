﻿using UnityEngine;
using System.Collections;

public class lazerMovement : MonoBehaviour {

	public float moveSpeed = 8f;// move speed at 8f per sec
	public float leftOrRightSpeed = 10f;// tilt speed at 10f per sec
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);//moves the lazer forward at movespeed per second

		/*
		FOR TESTING PURPOSES ONLY
		LATER CHANGES TO TILTING FOR TURNING
		*/
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * leftOrRightSpeed * Time.deltaTime);//If A is pressed turn left at leftOrRightSpeed per second
		}


		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * leftOrRightSpeed * Time.deltaTime);//If D is pressed turn right at leftOrRightSpeed per second
			
		}



	}

}//end of code
