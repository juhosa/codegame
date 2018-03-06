﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBaseRow : MonoBehaviour {

    private Vector3 startpo;
    private Vector2 lastpo;
    private float speed = 3f;

    public int rowSize = 1;
    public CodeBase basePrefab;
    public Reader readerPrefab;

    private void Start()
    {
        startpo = transform.position;

        for (int i=0; i<=rowSize; i++)
        {
            Vector2 posR = new Vector2(transform.position.x+(i*0.32f), transform.position.y);
            CodeBase basR = Instantiate(basePrefab, posR, Quaternion.identity);
            basR.transform.name = "CodeBase "+i;
            basR.transform.parent = transform;
            //Record position to lastpo if last created codebase
            if (i == rowSize)
            {
                lastpo = basR.transform.position;
            }
        }
    }

    public void RunCode()
    {
        if (!GameManager.instance.running)
        {
            GameManager.instance.running = true;
            /*
            int childBlocks = 0;
            //Count all children with sprites
            foreach (Transform child in transform)
            {
                if (child.GetComponent<CodeBase>().HasSprite())
                {
                    childBlocks += 1;
                }
            }
            */
            //Get the first base with a codeblock starting from the left
            foreach (Transform child in transform)
            {
                CodeBase childbase = child.GetComponent<CodeBase>();
                Vector2 pos = new Vector2(child.transform.position.x-0.16f, child.transform.position.y);
                Reader reader = Instantiate(readerPrefab, pos, Quaternion.identity);
                reader.transform.parent = transform;
                reader.posDifference = lastpo.x - startpo.x;
                break;
            }
        }
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