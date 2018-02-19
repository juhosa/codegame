using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBaseRow : MonoBehaviour {

    private Vector3 startpo;
    private float speed = 3f;

    private void Start()
    {
        startpo = transform.position;
    }

    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
