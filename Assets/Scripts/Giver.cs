using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giver : MonoBehaviour {

    public GameObject blockToGive;

    private void Update()
    {
        //Give vodeblock when clicked
        Vector2 clickpo = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        if (Input.GetMouseButtonDown(0) && (clickpo.x > -0.32f) && (clickpo.x < 0.32f) && (clickpo.y > -0.32f) && (clickpo.y < 0.32f))
        {
            Debug.Log("Clicked");
            Instantiate(blockToGive);
        }
    }
}
