using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    //Get the destination teleport pos (child)
    public Vector2 endPos;


    private void Start()
    {
        endPos = transform.GetChild(0).transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Player>().canMove)
        {
            collision.gameObject.transform.position = endPos;
        }
    }
}
