using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float moveSize = 0.32f;
    private float rayLength = 0.24f;
    private float rayLengthLong = 0.64f;
    private float moveTime = 0.1f;
    public LayerMask wallLayer;

    //States
    public bool dead = false;
    public bool canMove = true;
    public int dir = 0;

    private bool coroRunning = false;

    private Vector2 startPos;
    private int startDir;
    //0 = Right;
    //1 = Down;
    //2 = Left;
    //3 = Up;

    //Components
    public Animator anim;

    private Coroutine coro;

	void Start () {
        startPos = transform.position;
        startDir = dir;
        //Screen.SetResolution(640, 480, true);
        anim = GetComponent<Animator>();
        //Get first standing sprite defined by the dir
        RotateSprite();
	}
	
	void Update () {
        //Origin of the player
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);
        //Draw debug raycast lines
        //Debug.DrawRay(orig, Vector2.down * 0.01f, Color.red);
        //Debug.DrawRay(orig, Vector2.up * rayLengthLong, Color.red);
        //Debug.DrawRay(orig, Vector2.left * rayLengthLong, Color.red);
        //Debug.DrawRay(orig, Vector2.right * rayLengthLong, Color.red);

        //Fall to hole
        if (canMove && Physics2D.Raycast(orig, Vector2.down, 0.01f, (1<<9)))
        {
            Debug.Log("Hole!");
            dead = true;
        }

        //Fall to hole
        if (dead)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
        }

        //Restart scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Restart!");
            SceneManager.LoadScene("Main");
        }
    }

    public void MoveForward()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_down = Physics2D.Raycast(orig, Vector2.down, rayLength, wallLayer);
            RaycastHit2D ray_up = Physics2D.Raycast(orig, Vector2.up, rayLength, wallLayer);
            RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.left, rayLength, wallLayer);
            RaycastHit2D ray_right = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);

            if (dir == 3 && !ray_up)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y + moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerUp");
            }
            if (dir == 1 && !ray_down)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y - moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerDown");
            }
            if (dir == 0 && !ray_right)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x + moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerRight");
            }
            if (dir == 2 && !ray_left)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x - moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerLeft");
            }
        }
    }

    public void MoveBackward()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_down = Physics2D.Raycast(orig, Vector2.down, rayLength, wallLayer);
            RaycastHit2D ray_up = Physics2D.Raycast(orig, Vector2.up, rayLength, wallLayer);
            RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.left, rayLength, wallLayer);
            RaycastHit2D ray_right = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);

            if (dir == 3 && !ray_down)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y - moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerUp");
            }
            if (dir == 1 && !ray_up)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y + moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerDown");
            }
            if (dir == 0 && !ray_left)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x - moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerRight");
            }
            if (dir == 2 && !ray_right)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x + moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
                anim.Play("AnimPlayerLeft");
            }
        }
    }

    public void JumpForward()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_down = Physics2D.Raycast(orig, Vector2.down, rayLength, wallLayer);
            RaycastHit2D ray_up = Physics2D.Raycast(orig, Vector2.up, rayLength, wallLayer);
            RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.left, rayLength, wallLayer);
            RaycastHit2D ray_right = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);
            RaycastHit2D ray_downL = Physics2D.Raycast(orig, Vector2.down, rayLengthLong, wallLayer);
            RaycastHit2D ray_upL = Physics2D.Raycast(orig, Vector2.up, rayLengthLong, wallLayer);
            RaycastHit2D ray_leftL = Physics2D.Raycast(orig, Vector2.left, rayLengthLong, wallLayer);
            RaycastHit2D ray_rightL = Physics2D.Raycast(orig, Vector2.right, rayLengthLong, wallLayer);

            if (dir == 3 && !ray_up)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y + (!ray_upL?(moveSize*2):moveSize));
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
            if (dir == 1 && !ray_down)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y - (!ray_downL ? (moveSize * 2) : moveSize));
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
            if (dir == 0 && !ray_right)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x + (!ray_rightL ? (moveSize * 2) : moveSize), transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
            if (dir == 2 && !ray_left)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x - (!ray_leftL ? (moveSize * 2) : moveSize), transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
        }
    }

    public IEnumerator MoveToPosition(Vector3 orig, Vector3 position)
    {
        coroRunning = true;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(orig, position, t);
            yield return null;
        }
        canMove = true;
        coroRunning = false;
        //Get reader
        GameObject readerObject = GameObject.Find("BaseReader(Clone)");
        if (readerObject != null)
        {
            Reader reader = readerObject.GetComponent<Reader>();
            reader.wait = false;
        }
    }

    public void RotateRight()
    {
        if (canMove && !dead)
        {
            if (dir == 3)
            {
                dir = 0;
            }
            else
            {
                dir += 1;
            }
            RotateSprite();
        }
    }

    public void RotateLeft()
    {
        if (canMove && !dead)
        {
            if (dir == 0)
            {
                dir = 3;
            }
            else
            {
                dir -= 1;
            }
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        if (dir == 0) { anim.Play("AnimPlayerRightIdle"); }
        if (dir == 1) { anim.Play("AnimPlayerDownIdle"); }
        if (dir == 2) { anim.Play("AnimPlayerLeftIdle"); }
        if (dir == 3) { anim.Play("AnimPlayerUpIdle"); }
    }

    public void ReturtToStart()
    {
        //Stop everything
        if (coroRunning) { StopCoroutine(coro); }
        transform.position = startPos;
        dir = startDir;
        canMove = true;
        dead = false;
        transform.localScale = new Vector3(1, 1, 1);
        RotateSprite();
    }

    public void MoveUp()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_up = Physics2D.Raycast(orig, Vector2.up, rayLength, wallLayer);

            if (!ray_up)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y + moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
        }
    }
    public void MoveRight()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_right = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);

            if (!ray_right)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x + moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
        }
    }
    public void MoveLeft()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);

            if (!ray_left)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x - moveSize, transform.position.y);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
        }
    }
    public void MoveDown()
    {
        if (canMove && !dead)
        {
            //Origin of the player
            Vector2 orig = new Vector2(transform.position.x, transform.position.y);
            //Raycasting
            RaycastHit2D ray_left = Physics2D.Raycast(orig, Vector2.right, rayLength, wallLayer);

            if (!ray_left)
            {
                canMove = false;
                Vector3 target = new Vector3(transform.position.x, transform.position.y - moveSize);
                coro = StartCoroutine(MoveToPosition(orig, target));
            }
        }
    }
}
