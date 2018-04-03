using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    private GameObject mainCamera;
    private GameObject levelCanvas;

    public GameObject endPrefab;

    public string destinationScene;
    private bool expand = true;
    public int instant = 0;
    

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        levelCanvas = GameObject.Find("/Main Camera/Canvas");
        StartCoroutine(WaitAndGo());
    }

    private void Update()
    {
        if (expand)
        {
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + 1.5f);
        }
        else
        {
            if (Input.anyKey)
            {
                //Change room
                UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
            }
        }
    }

    private IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(0.5f);
        if (instant == 0)
        {
            GameObject end = Instantiate(endPrefab);
            end.transform.SetParent(levelCanvas.transform, false);
            expand = false;
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
        }
    }
}
