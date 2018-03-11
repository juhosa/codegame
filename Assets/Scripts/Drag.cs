using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {

    public bool locked = false;
    public bool follow = true;

    private float speed = 0.25f;
    private Vector3 returnPos;
    public Vector3 startPos;
    private CodeBase targetBase;
    private Giver targetGiver;

    void Start()
    {
        returnPos = startPos;
    }

    void Update()
    {
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if (!locked)
        {
            //Follow cursor when clicked
            if (Input.GetMouseButtonDown(0) && (clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f))
            {
                follow = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                follow = false;
            }
        }

        //Jump to cursor position if following
        if (follow)
        {
            Vector3 mousepo = (Camera.main.ScreenToWorldPoint(Input.mousePosition));
            transform.position = new Vector3(mousepo.x,mousepo.y,mousepo.z+9.9f);
        }
        else
        {
            //Else lerp back to start
            transform.position = Vector2.Lerp(transform.position, returnPos, speed);
        }

        //Destroy if at starting pos
        if (Vector3.Distance(transform.position,returnPos)<=0.16f && !follow)
        {
            if (targetBase!=null && returnPos==targetBase.transform.position)
            {
                targetBase.ChangeToBlock(GetComponent<SpriteRenderer>().sprite, startPos);
            }
            else
            {
                //Give count++ to the giver if sprites are the same
                Giver[] allObjects = FindObjectsOfType<Giver>();
                foreach (Giver giv in allObjects)
                {
                    if (this.GetComponent<SpriteRenderer>().sprite == giv.GetComponent<SpriteRenderer>().sprite)
                    {
                        giv.count++;
                    }
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (follow)
        {
            targetBase = collision.gameObject.GetComponent<CodeBase>();
            returnPos = new Vector2(collision.transform.position.x, collision.transform.position.y);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        returnPos = startPos;
    }
}
