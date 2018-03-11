using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CodeBase : MonoBehaviour {

    public Drag codeBlock;

    private SpriteRenderer sr;
    private Sprite spriteOrig;
    public Sprite[] spriteLoopBlock;
    public Sprite[] spriteLoopBlockEnd;
    public int currentSprite=0;

    private Vector3 _startPos;

    public bool used = false;

    public int blockId;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteOrig = sr.sprite;
    }

    private void Update()
    {
        //Change id according to sprite
        if (Array.IndexOf(spriteLoopBlockEnd, sr.sprite) > -1)
        {
            blockId = 2;
        }
        if (Array.IndexOf(spriteLoopBlock, sr.sprite) > -1)
        {
            blockId = 1;
        }
        if (sr.sprite!=spriteOrig && !GameManager.instance.running)
        {
            Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            Vector2 clickpoGlobal = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            //Check if mouse on top
            if ((clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f) && clickpoGlobal.x > 0.32f && clickpoGlobal.x < 6.08f)
            {
                //Give codeblock when clicked
                if (Input.GetMouseButtonDown(0))
                {
                    Vector2 middle = new Vector2(transform.position.x, transform.position.y);
                    Drag block = Instantiate(codeBlock, middle, Quaternion.identity);
                    block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
                    block.startPos = _startPos;
                    sr.sprite = spriteOrig;
                    blockId = 0;
                }
                //Change with mouse wheel if id = 0 (loop)
                if (blockId == 1 || blockId==2)
                {
                    //Up
                    if (Input.GetAxis("Mouse ScrollWheel") > 0)
                    {
                        if (currentSprite < 8) { currentSprite++; }
                        if (blockId == 1)
                        {
                            sr.sprite = spriteLoopBlock[currentSprite];
                        }
                        else
                        {
                            sr.sprite = spriteLoopBlockEnd[currentSprite];
                        }
                    }
                    //Down
                    if (Input.GetAxis("Mouse ScrollWheel") < 0)
                    {
                        if (currentSprite > 0) { currentSprite--; }
                        if (blockId == 1)
                        {
                            sr.sprite = spriteLoopBlock[currentSprite];
                        }
                        else
                        {
                            sr.sprite = spriteLoopBlockEnd[currentSprite];
                        }
                    }
                }

                //Destroy with left click
                if (Input.GetMouseButtonDown(1))
                {
                    //Reset sprite to the first one of the array when left clicked so count++ works
                    if (blockId == 1) { sr.sprite = spriteLoopBlock[0]; }
                    if (blockId == 2) { sr.sprite = spriteLoopBlockEnd[0]; }
                    ReturnToStart();
                }
            }
        }
    }

    public void ReturnToStart()
    {
        if (HasSprite())
        {
            Vector2 middle = new Vector2(transform.position.x, transform.position.y);
            Drag block = Instantiate(codeBlock, middle, Quaternion.identity);
            block.follow = false;
            block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
            block.startPos = _startPos;
            block.locked = true;
            sr.sprite = spriteOrig;
            //Return the block id to 0, since the block is gone
            blockId = 0;
        }
    }

    public bool HasSprite()
    {
        //Debug.Log(sr.sprite != spriteOrig);
        return sr.sprite != spriteOrig;
    }

    public Sprite GetSprite()
    {
        return sr.sprite;
    }

    public void ChangeToBlock(Sprite changeTo, Vector3 startPos)
    {
        if (sr.sprite!=spriteOrig)
        {
            Vector2 middle = new Vector2(transform.position.x, transform.position.y);
            Drag block = Instantiate(codeBlock, middle, Quaternion.identity);
            block.follow = false;
            block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
            block.startPos = _startPos;
            block.locked = true;
        }
        _startPos = startPos;
        sr.sprite = changeTo;
    }

    private Transform NextChild()
    {
        // Check where we are
        int thisIndex = this.transform.GetSiblingIndex();

        // We have a few cases to rule out
        if (this.transform.parent == null)
            return null;
        if (this.transform.parent.childCount <= thisIndex + 1)
            return null;

        // Then return whatever was next, now that we're sure it's there
        return this.transform.parent.GetChild(thisIndex + 1);
    }

    public void Used()
    {
        used = true;
    }
}
