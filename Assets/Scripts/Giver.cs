using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giver : MonoBehaviour {

    public Drag blockToGive;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Give vodeblock when clicked
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if (Input.GetMouseButtonDown(0) && (clickpo.x > -0.32f) && (clickpo.x < 0.32f) && (clickpo.y > -0.32f) && (clickpo.y < 0.32f))
        {
            Vector2 middle = new Vector2(transform.position.x, transform.position.y);
            Drag block = Instantiate(blockToGive, middle, Quaternion.identity);
            block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
            block.startPos = middle;
        }
    }
}
