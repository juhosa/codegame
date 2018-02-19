using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBase : MonoBehaviour {

    public bool occupied = false;

    private void Update()
    {
        if (occupied)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        occupied = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        occupied = false;
    }
}
