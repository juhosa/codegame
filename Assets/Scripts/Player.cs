using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float moveSize = 0.64f;

	void Start () {
		
	}
	
	void Update () {

        //Origin of the player
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);

        //Draw debug raycast lines
        Debug.DrawRay(orig, Vector2.up * 0.64f, Color.red);
        Debug.DrawRay(orig, Vector2.down * 0.64f, Color.red);
        Debug.DrawRay(orig, Vector2.left * 0.64f, Color.red);
        Debug.DrawRay(orig, Vector2.right * 0.64f, Color.red);
        //Movement with WASD
        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.up, 0.64f);
            if (!ray)
            {
                transform.position += new Vector3(0, moveSize);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.down, 0.64f);
            if (!ray)
            {
                transform.position += new Vector3(0, -moveSize);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.right, 0.64f);
            if (!ray)
            {
                transform.position += new Vector3(moveSize, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.left, 0.64f);
            if (!ray)
            {
                transform.position += new Vector3(-moveSize, 0);
            }
        }
    }
}
