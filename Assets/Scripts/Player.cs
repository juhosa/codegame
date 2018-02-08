using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float moveSize = 0.32f;
    private float rayLenght = 0.24f;

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
        //Screen.SetResolution(640, 480, true);
        anim = GetComponent<Animator>();
	}
	
	void Update () {

        //Draw debug raycast lines
        //Debug.DrawRay(orig, Vector2.down * rayLenght, Color.red);
        //Debug.DrawRay(orig, Vector2.up * rayLenght, Color.red);
        //Debug.DrawRay(orig, Vector2.left * rayLenght, Color.red);
        //Debug.DrawRay(orig, Vector2.right * rayLenght, Color.red);

        //If not dead allow movement
        if (!dead)
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
        /*
        if (dead)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.1f, transform.position.z);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
        }
        */

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
        //Origin of the player
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);
        //Raycasting
        RaycastHit2D ray_down = Physics2D.Raycast(orig, Vector2.down, rayLenght);
        RaycastHit2D ray_up = Physics2D.Raycast(orig, Vector2.up, rayLenght);
        RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.left, rayLenght);
        RaycastHit2D ray_right = Physics2D.Raycast(orig, Vector2.right, rayLenght);

        if (dir==3 && !ray_up)
        {
            transform.position += new Vector3(0, moveSize);
        }
        if (dir==1 && !ray_down)
        {
            transform.position += new Vector3(0, -moveSize);
        }
        if (dir==0 && !ray_right)
        {
            transform.position += new Vector3(moveSize, 0);
        }
        if (dir==2 && !ray_left)
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
