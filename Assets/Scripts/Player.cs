using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float moveSize = 0.32f;

    //States
    bool dead = false;
    public int dir = 0;
    //0 = Right;
    //1 = Down;
    //2 = Left;
    //3 = Up;

    //Components
    public Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {

        //Origin of the player
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);

        //Draw debug raycast lines
        Debug.DrawRay(orig, Vector2.down * 0.08f, Color.red);
        //Raycast
        RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.down, 0.08f);

        //If ground under feet, move with WASD
        if (ray && !dead)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Turn90Degrees();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveForward();
            }
        }
        else
        {
            //Die if no ground under feet
            if (!dead)
            {
                dead = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
                anim.Play("AnimPlayerDie");
            }
        }

        //If dead, just fall down
        if (dead)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
        }

        //Animations
        if (!dead)
        {
            if (dir == 0) { anim.Play("AnimPlayerRight"); }
            if (dir == 1) { anim.Play("AnimPlayerDown"); }
            if (dir == 2) { anim.Play("AnimPlayerLeft"); }
            if (dir == 3) { anim.Play("AnimPlayerUp"); }
        }

        //Restart scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void MoveForward()
    {
        if (dir==3)
        {
            transform.position += new Vector3(0, moveSize);
        }
        if (dir==1)
        {
            transform.position += new Vector3(0, -moveSize);
        }
        if (dir==0)
        {
            transform.position += new Vector3(moveSize, 0);
        }
        if (dir==2)
        {
            transform.position += new Vector3(-moveSize, 0);
        }
    }

    public void Turn90Degrees()
    {
        if (dir==3)
        {
            dir = 0;
        }
        else
        {
            dir += 1;
        }
    }
}
