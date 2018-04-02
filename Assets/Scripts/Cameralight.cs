using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralight : MonoBehaviour {

    public bool opened = false;
    public int dir = 1;
    //1=Horizontal
    //2=Vertical

    //Get components
    private BoxCollider2D bc2d;

    private void Start()
    {
        bc2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (opened)
        {
            if (dir==1 && transform.localScale.y > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 0.05f, transform.localScale.z);
            }
            if (dir == 2 && transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public void Open()
    {
        opened = true;
        bc2d.enabled = false;
    }

    public void ResetLight()
    {
        opened = false;
        transform.localScale = new Vector3(1, 1, 1);
        bc2d.enabled = true;
    }
}
