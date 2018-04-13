using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttonLevelSelect : MonoBehaviour
{

    public string destinationScene = "Menu";
    public int levelId = 0;

    private bool locked = true;

    private SpriteRenderer sr;

    public GameObject coinPrefab;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        //Define state according to savedata
        if (GameManager.instance.levelData[levelId]<1)
        {
            locked = true;
            sr.color = Color.gray;
        }
        else
        {
            locked = false;
            if (GameManager.instance.levelData[levelId] == 3)
            {
                Vector2 pos = new Vector2(transform.position.x+0.425f, transform.position.y);
                GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity);
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !locked)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
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
