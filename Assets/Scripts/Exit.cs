using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public int keysNeeded;
    private bool opened;

    private Animator anim;
    private BoxCollider2D bc2d;
    private Player playerObject;

    public Transition transitionPrefab;
    public string nextLevel = "Menu";
    public int levelId = 0;
    public int levelCoins = 0;

    private void Start()
    {
        //Save the level as 1 if first time in level
        if (GameManager.instance.levelData[levelId] < 1)
        {
            GameManager.instance.levelData[levelId] = 1;
            GameManager.instance.SaveLevel();
        }

        anim = GetComponent<Animator>();
        bc2d = GetComponent<BoxCollider2D>();
        //Get player to do actions for him
        GameObject player = GameObject.Find("/Grid/Player");
        playerObject = player.GetComponent<Player>();
    }

    private void Update()
    {
        if (keysNeeded==0 && !opened)
        {
            opened = true;
            anim.SetBool("Open",opened);
            bc2d.enabled = false;
        }
        if (opened && playerObject.transform.position == transform.position && !GameManager.instance.levelCompleted)
        {
            //Complete the level if player at position
            GameManager.instance.levelCompleted = true;

            Vector2 pos = new Vector2(3.2f, 5.1f);
            Transition tra = Instantiate(transitionPrefab, pos, Quaternion.identity) as Transition;
            tra.destinationScene = nextLevel;

            //Save level done
            if (GameManager.instance.coins == levelCoins)
            {
                GameManager.instance.levelData[levelId] = 3;
            }
            else
            {
                if (GameManager.instance.levelData[levelId] < 3)
                {
                    GameManager.instance.levelData[levelId] = 2;
                }
            }
            GameManager.instance.SaveLevel();
        }
    }

    public void ResetDoor()
    {
        opened = false;
        anim.SetBool("Open", opened);
        bc2d.enabled = true;
        keysNeeded = 1;
    }
}
