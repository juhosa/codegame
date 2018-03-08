using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giver : MonoBehaviour {

    public Drag blockToGive;
    private SpriteRenderer sr;

    public int count;

    private float range=0.24f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Give codeblock when clicked
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if (count>0 && !GameManager.instance.running && Input.GetMouseButtonDown(0) && (clickpo.x > -range) && (clickpo.x < range) && (clickpo.y > -range) && (clickpo.y < range))
        {
            Vector2 middle = new Vector2(transform.position.x, transform.position.y);
            Drag block = Instantiate(blockToGive, middle, Quaternion.identity);

            block.GetComponent<SpriteRenderer>().sprite = sr.sprite;

            block.startPos = middle;

            count--;
        }
    }
}
