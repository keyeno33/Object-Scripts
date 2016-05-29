using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int speed;
    public string ObjSpeedIncr = "Speed_Cube";
    public string ObjSpeedDec = "Dec_Speed_Cube";
    public string ObjScaleinc = "Scale_Inc";
    public string ObjScaleDec = "Scale_Dc";

    private Rigidbody rb;
	
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate () {
        
        //Get input for each axis;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moverVertical);
        rb.AddForce(movement * speed);
	}
    void OnCollisionEnter(Collision col)
    {
        //initial state of collision 
        bool collisionState = false;

        //switch case for each object collision
        switch(collisionState)
        {
            case gameObject.name == ObjSpeedIncr:
                    Destroy(col.gameObject);
                    speed = 20;
                break;

            case gameObject.name == ObjSpeedIncr:
                    Destroy(col.gameObject);
                    speed -= 5;
                break;

            case gameObject.name == ObjScaleinc:

            break;

            case gameObject.name == ObjScaleDec:
                break;
                  
            default:
                return collisionState;
        }
}
