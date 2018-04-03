using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbutton : MonoBehaviour {

    public int type = 0;
    //0 = run code
    //1 = stop code
    //2 = clear code
    //3 = quit game

    //Objects to store
    public CodeBaseRow row;

    private void Start()
    {
        //Get codebaserow
        if (GameObject.Find("CodeBaseRow"))
        {
            GameObject roww = GameObject.Find("CodeBaseRow");
            row = roww.GetComponent<CodeBaseRow>();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            if (type == 0)
            {
                row.RunCode();
            }
            if (type == 1)
            {
                row.StopCode();
            }
            if (type == 2)
            {
                row.ClearCode();
            }
        }
    }
}
