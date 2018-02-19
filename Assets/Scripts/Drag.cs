using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public bool secondBlock = false;

    private float speed = 0.25f;
    private bool follow = true;
    private Vector3 returnPos;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        returnPos = transform.position;
    }

    void Update()
    {
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //Debug.Log(clickpo);
        if (Input.GetMouseButtonDown(0) && (clickpo.x>-0.16f) && (clickpo.x <0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f))
        {
            follow = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            follow = false;
        }

        if (follow)
        {
            Vector3 mousepo = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            transform.position = new Vector3(mousepo.x,mousepo.y,mousepo.z+9.9f);
        }
        else
        {
            transform.position = Vector2.Lerp(transform.position, returnPos, speed);
        }

        //Destroy with left click
        if (Input.GetMouseButtonDown(1) && !follow && (clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f))
        {
            Destroy(gameObject);
        }

        //Destroy if at starting pos
        {
            if (Vector3.Distance(transform.position,startPos)<=0.16f && !follow)
            {
                Destroy(gameObject);
            }
        }
        Debug.Log(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (follow && !collision.gameObject.GetComponent<CodeBase>().occupied)
        {
            returnPos = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }
    }
}
