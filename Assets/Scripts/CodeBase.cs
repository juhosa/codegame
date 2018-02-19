using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBase : MonoBehaviour {

    public Drag codeBlock;

    private SpriteRenderer sr;
    private Sprite spriteOrig;

    private Vector3 _startPos;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        spriteOrig = sr.sprite;
    }

    private void Update()
    {
        if (sr.sprite!=spriteOrig)
        {
            Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            Vector2 clickpoGlobal = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(clickpoGlobal);
            //Give vodeblock when clicked
            if (Input.GetMouseButtonDown(0) && (clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f) && clickpoGlobal.x>0.32f && clickpoGlobal.x < 6.08f)
            {
                Vector2 middle = new Vector2(transform.position.x, transform.position.y);
                Drag block = Instantiate(codeBlock, middle, Quaternion.identity);
                block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
                block.startPos = _startPos;
                sr.sprite = spriteOrig;
            }
            //Destroy with left click
            if (Input.GetMouseButtonDown(1) && (clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f))
            {
                Vector2 middle = new Vector2(transform.position.x, transform.position.y);
                Drag block = Instantiate(codeBlock, middle, Quaternion.identity);
                block.follow = false;
                block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
                block.startPos = _startPos;
                block.locked = true;
                sr.sprite = spriteOrig;
            }
        }
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
}
