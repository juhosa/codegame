using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbutton : MonoBehaviour
{

    public int type = 0;
    //0 = Run code
    //1 = Stop code
    //2 = Clear code
    //3 = Quit game

    //4 = Play game (to level select)
    //5 = Quit game (menu)

    //6 = Back (level select)

    private SpriteRenderer sr;

    //Objects to store
    public CodeBaseRow row;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

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
            if (type == 3)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
            }

            //Menu
            if (type == 4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
            }
            if (type == 5)
            {
                Application.Quit();
            }
            if (type == 6)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
            }

            StartCoroutine(ClickResponse());
        }
    }

    private IEnumerator ClickResponse()
    {
        sr.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
}
