using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    GameObject mainCamera;

    public string destinationScene;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        StartCoroutine(WaitAndGo());
    }

    private void Update()
    {
        transform.localScale = new Vector2(transform.localScale.x,transform.localScale.y+1.5f);
    }

    private IEnumerator WaitAndGo()
    {
        yield return new WaitForSeconds(0.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
    }
}
