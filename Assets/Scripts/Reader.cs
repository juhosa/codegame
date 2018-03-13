﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour {

    private float speed=2f;
    private float rayLength = 0.01f;
    public LayerMask codeBlockLayer;

    public Player playerObject;

    public float posDifference;
    private Vector2 startpo;

    //Array to store loop positions in
    public Vector2[] loopPositions;

    //Codeblock sprites
    public Sprite[] codeBlockSprite;

    //Stop the reader if needed
    public bool wait = false;

    private void Start()
    {
        //Get player to do actions for him
        GameObject player = GameObject.Find("/Grid/Player");
        playerObject = player.GetComponent<Player>();
    }

    private void Update()
    {
        //Get startpo each frame since it's the parent's startpo
        startpo = transform.parent.transform.position;
        //Move to the right
        if (!wait)
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        //Destroy reader if over the last codebase
        if (transform.position.x > (startpo.x + posDifference))
        {
            Stop();
        }

        //Raycast and see collisions with block
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.right, rayLength, codeBlockLayer);
        //Debug.DrawRay(orig, Vector2.right * rayLength, Color.green);
        if (ray)
        {
            CodeBase rayCodebase = ray.collider.gameObject.GetComponent<CodeBase>();

            if (!rayCodebase.used && rayCodebase.HasSprite())
            {
                //Make player do actions corresponding the codebase
                if (rayCodebase.GetSprite() == codeBlockSprite[0])
                {
                    rayCodebase.Used();
                    playerObject.MoveForward();
                }
                if (rayCodebase.GetSprite() == codeBlockSprite[1])
                {
                    rayCodebase.Used();
                    playerObject.RotateRight();
                }
                if (rayCodebase.GetSprite() == codeBlockSprite[2])
                {
                    rayCodebase.Used();
                    playerObject.RotateLeft();
                }
                if (rayCodebase.GetSprite() == codeBlockSprite[3])
                {
                    rayCodebase.Used();
                    playerObject.MoveBackward();
                }
                if (rayCodebase.GetSprite() == codeBlockSprite[4])
                {
                    rayCodebase.Used();
                    playerObject.JumpForward();
                }

                //React to loop blocks
                if (rayCodebase.blockId == 2)
                {
                    rayCodebase.used = true;
                    loopPositions[rayCodebase.currentSprite] = rayCodebase.transform.position;
                }
                if (rayCodebase.blockId == 1)
                {
                    rayCodebase.used = true;
                    //Loop cant work if you touch the start-one first
                    if (loopPositions[rayCodebase.currentSprite].x != 0)
                    {
                        transform.position = loopPositions[rayCodebase.currentSprite];
                    }
                }
            }
        }
        //Stop if level completed
        if (GameManager.instance.levelCompleted)
        {
            Stop();
        }
    }

    public void Stop()
    {
        if (!GameManager.instance.levelCompleted)
        {
            GameManager.instance.running = false;
            //Reset all codebases so they can be used again
            CodeBase[] allObjects = FindObjectsOfType<CodeBase>();
            foreach (CodeBase cb in allObjects)
            {
                cb.used = false;
            }

            //Return player to start
            playerObject.ReturtToStart();
        }
        Destroy(gameObject);
    }
}
