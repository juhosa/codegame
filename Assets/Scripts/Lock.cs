using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    public bool opened = false;

    //Get components
    private BoxCollider2D bc2d;

    private void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (opened && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
        }
    }

    public void Open()
    {
        opened = true;
        bc2d.enabled = false;
    }

    public void ResetDoor()
    {
        opened = false;
        transform.localScale = new Vector3(1, 1, 1);
        bc2d.enabled = true;
    }
}
