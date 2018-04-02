using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowButton : MonoBehaviour {

    public GameObject row;
    public bool left = true;

    private void Update()
    {
        if (!GameManager.instance.running && !GameManager.instance.levelCompleted)
        {
            Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            //Debug.Log(clickpo);
            if (Input.GetMouseButton(0) && left && ((clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f)))
            {
                row.GetComponent<CodeBaseRow>().MoveLeft();
            }
            if (Input.GetMouseButton(0) && !left && ((clickpo.x > -0.16f) && (clickpo.x < 0.16f) && (clickpo.y > -0.16f) && (clickpo.y < 0.16f)))
            {
                row.GetComponent<CodeBaseRow>().MoveRight();
            }
        }
    }
}
