using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public bool collisionState = false;        //initial state of collision 
    public int speed;
    public string ObjSpeedIncr = "Speed_Cube;
    public string ObjSpeedDec = "Dec_Speed_Cube";
    public string ObjScaleinc = "Scale_Inc";
    public string ObjScaleDec = "Scale_Dc";

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Get input for each axis;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moverVertical);
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
        //switch case for each object collision
        SpecObjfunctions();
    }

    bool SpecObjfunctions()
    {
        switch (gameObject.name)
        {
            case ObjSpeedIncr:
                speed = 20;
                return collisionState = true;
                break;

            case ObjSpeedIncr:
                speed -= 5;
                return collisionState = true;
                break;

            case ObjScaleinc:
                return collisionState = true;
                break;
                
            case ObjScaleDec:
                return collisionState = true;
                break;

            default:
                return collisionState;
                break;
        }
    }
}
