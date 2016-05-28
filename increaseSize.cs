using UnityEngine;
using System.Collections;

public class increaseSize : MonoBehaviour {
    public int size;
  
	// Use this for initialization
	void Start () {
        Transfrom.Scale(size, size, size);
	}
	
	// Update is called once per frame
	void Update () {

}
