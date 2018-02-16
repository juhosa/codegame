using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    //Define required key type
    public bool opened = false;

    private void Update()
    {
        if (opened)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void Open()
    {
        opened = true;
    }
}
