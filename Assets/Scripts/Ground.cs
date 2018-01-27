using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {


	void Start () {
        //Set the depth to y so the terraina appears behind toher terrain pieces
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
}
