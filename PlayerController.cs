using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

	public float moveSpeed = 15f;// move speed at 8f per sec
	public float leftOrRightSpeed = 10f;// tilt speed at 10f per sec
	public bool collisionState;        //initial state of collision 
	public float speed = 90f;
	public string[] specObjects = new string[] { "Speed_Cube", "Dec_Speed_Cube", "Scale_Inc", "Scale_Dc"};
	public const string ObjSpeedIncr = "Speed_Cube";
	public const string ObjSpeedDec = "Dec_Speed_Cube";
	public const string ObjScaleinc = "Scale_Inc";
	public const string ObjScaleDec = "Scale_Dc";
	public const string ObjMirror = "Mirror";
	private Rigidbody rb;
	public float hoverForce = 65f;
	public float hoverHeight = 2f;
	public string objName;
	public GameObject Mirror;
	Vector3 forceDirection = Vector3.forward;

	void Awake()
	{
		Mirror = GameObject.Find ("Mirror");
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;

	}

	// Update is called once per frame
	void Update()
	{

		//transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);//moves the lazer forward at movespeed per second

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * leftOrRightSpeed * Time.deltaTime);//If A is pressed turn left at leftOrRightSpeed per second
		}


		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * leftOrRightSpeed * Time.deltaTime);//If D is pressed turn right at leftOrRightSpeed per second	
		}

	}

	//collision codes
	void OnCollisionEnter(Collision col)
	{


		switch (col.gameObject.name)      
		{

		case ObjMirror:
			//call lazer reflection function
		case ObjSpeedIncr:
			
			moveSpeed = 100;
			Destroy (col.gameObject);
			break;

		case ObjSpeedDec:
			moveSpeed = 40;
			Destroy (col.gameObject);
			break;

		case ObjScaleinc:
			//transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
			Debug.Log(ObjScaleinc);
			Destroy (col.gameObject);
			break;

		case ObjScaleDec:
			//transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
			Debug.Log(ObjScaleDec);
			Destroy (col.gameObject);
			break;

		default:
			printObjName(col);
			break;
		}
	}

	void printObjName(Collision col)
	{
		for (int i = 0; i < specObjects.Length; i++)
		{
			if (col.gameObject.name == specObjects[i])
			{
				Debug.Log(specObjects[i]);
			}
		}
	}

	void mirrorReflection(){

	}

	void FixedUpdate(){

		//hoverCode
		rb.AddForce (forceDirection * moveSpeed);

		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			rb.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}
	}


	void lazerReflection(){
		//90 degrees = first right while lazer rotation is at 0


		/*
		if (rb.transform.rotation.eulerAngles.y == 0) {
		
			if (Mirror.transform.Rotate == 315){
			gameObject.transform.Rotate (0, 90, 0); --- rotate lazer 90 degrees
			forceDirection = Vector3.right; --- turn lazer right
		}
		if (Mirror.transform.Rotate == 45){
			gameObject.transform.Rotate (0, 270, 0); --- rotate lazer 270 degrees
			forceDirection = Vector3.left; --- turn lazer left
		}

		}





		if (rb.transform.rotation.eulerAngles.y == 90) {

			if (Mirror.transform.Rotate == 225){
			gameObject.transform.Rotate (0, 180, 0); --- rotate lazer 180 degrees
			forceDirection = Vector3.right; --- turn lazer right
		}
		if (Mirror.transform.Rotate == 315){
			gameObject.transform.Rotate (0, 0, 0); --- rotate lazer 0 degrees
			forceDirection = Vector3.left; --- turn lazer left
		}





		} if (rb.transform.rotation.eulerAngles.y == 180) {

			if (Mirror.transform.Rotate == 135){
				gameObject.transform.Rotate (0, 270, 0); --- rotate lazer 270 degrees
				forceDirection = Vector3.right; --- turn lazer right
			}
			if (Mirror.transform.Rotate == 225){
				gameObject.transform.Rotate (0, 90, 0); --- rotate lazer 90 degrees
				forceDirection = Vector3.left; --- turn lazer left
			}

		} 





		if (rb.transform.rotation.eulerAngles.y == 270) {

			if (Mirror.transform.Rotate == 45){
				gameObject.transform.Rotate (0, 0, 0); --- rotate lazer  degrees
				forceDirection = Vector3.right; --- turn lazer right
			}
			if (Mirror.transform.Rotate == 135){
				gameObject.transform.Rotate (0, 180, 0); --- rotate lazer 180 degrees
				forceDirection = Vector3.left; --- turn lazer left
			}	

		}

		*/
	}

}




