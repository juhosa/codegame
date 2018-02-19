using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowButton : MonoBehaviour {

    public GameObject row;
    public bool left = true;

    private void Update()
    {
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        //Debug.Log(clickpo);
        if (left && ((clickpo.x < 0.16f) && (clickpo.y > -0.24f) && (clickpo.y < 0.24f)))
        {
            row.GetComponent<CodeBaseRow>().MoveLeft();
        }
        if (!left && ((clickpo.x > -0.16f) && (clickpo.y > -0.24f) && (clickpo.y < 0.24f)))
        {
            row.GetComponent<CodeBaseRow>().MoveRight();
        }
    }
}
