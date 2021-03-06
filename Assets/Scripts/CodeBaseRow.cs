﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeBaseRow : MonoBehaviour {

    private Vector3 startpo;
    private float speed = 3f;

    public int rowSize = 1;
    public CodeBase basePrefab;
    public Reader readerPrefab;
    public Giver giverPrefab;
    private Reader reader;
    //Text and canvas for instantiation
    public Text textPrefab;
    public Canvas levelCanvas;

    //Array and stuff for creating the codeblock givers
    public Sprite[] codeGivers;
    public int[] codeGiverCounts;

    private void Start()
    {
        //Reset running and finished since new level
        GameManager.instance.levelCompleted = false;
        GameManager.instance.running = false;
        GameManager.instance.coins = 0;

        startpo = transform.position;
        //Create the coderow
        for (int i=0; i<=rowSize; i++)
        {
            Vector2 posR = new Vector2(transform.position.x+(i*0.32f), transform.position.y);
            CodeBase basR = Instantiate(basePrefab, posR, Quaternion.identity);
            basR.transform.name = "CodeBase "+i;
            basR.transform.parent = transform;
        }
        //Create the codeblock givers
        for (int i=0; i<codeGivers.Length; i++)
        {
            startpo = new Vector2(0.32f+(i*0.48f), 0.64f);
            Giver giv = Instantiate(giverPrefab, startpo, Quaternion.identity);
            giv.transform.name = "Giver " + i;
            giv.GetComponent<SpriteRenderer>().sprite = codeGivers[i];
            giv.count = codeGiverCounts[i];
            //Text for codegiver
            Text givText = Instantiate(textPrefab, Vector2.zero, Quaternion.identity);
            givText.transform.SetParent(levelCanvas.transform,false);
            givText.rectTransform.localPosition = new Vector2(-576+(i*96), -465);
            giv.textUi = givText;

        }
    }

    public void RunCode()
    {
        if (!GameManager.instance.running && !GameManager.instance.levelCompleted)
        {
            GameManager.instance.running = true;

            //Get the first base with a codeblock starting from the left
            foreach (Transform child in transform)
            {
                CodeBase childbase = child.GetComponent<CodeBase>();
                Vector2 pos = new Vector2(child.transform.position.x-0.16f, child.transform.position.y);
                reader = Instantiate(readerPrefab, pos, Quaternion.identity);
                reader.transform.parent = transform;
                reader.posDifference = rowSize * 0.32f+0.16f;
                break;
            }
        }
    }

    public void StopCode()
    {
        if (reader != null && !GameManager.instance.levelCompleted)
        {
            reader.Stop();
            //Also reset coins
            GameManager.instance.coins = 0;
        }
    }

    public void ClearCode()
    {
        if (!GameManager.instance.running && !GameManager.instance.levelCompleted)
        {
            //Reset all bases
            CodeBase[] allBases = FindObjectsOfType<CodeBase>();
            foreach (CodeBase cb in allBases)
            {
                cb.ReturnToStart();
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
