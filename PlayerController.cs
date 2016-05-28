using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int speed;

    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
    // Update is called once per frame
    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moverVertical);
        rb.AddForce(movement * speed);
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Speed_Cube")
        {

            Destroy(col.gameObject);
            speed = 20;
        }
        else if (col.gameObject.name == "Dec_Speed_cube")
        {
            Destroy(col.gameObject);
            speed -= 5;
        }
    }
}
