using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    //Define the ype of the item
    public int type = 0;
    public GameObject[] locks;
    //1 = Key
    //2 = Coin
    //3 = Exit key
    public Exit exit;
    //Sprite renderer and used variable
    private SpriteRenderer sr;
    private bool used = false;

    private void Start()
    {
        //Get renderer
        sr = GetComponent<SpriteRenderer>();
        //Get exit
        GameObject exitObject = GameObject.Find("Exit");
        exit = exitObject.GetComponent<Exit>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name=="Player" && collision.gameObject.GetComponent<Player>().canMove && !used)
        {
            //Key
            if (type==1)
            {
                Debug.Log("Got Key!");
                foreach (GameObject l in locks)
                {
                    l.GetComponent<Lock>().Open();
                }
                Used();
            }
            //Coin
            if (type==2)
            {
                Debug.Log("Got coin!");
                GameManager.instance.coins += 1;
                Used();
            }
            //Exit Key
            if (type == 3)
            {
                Debug.Log("Got exit key!");
                exit.keysNeeded--;
                Used();
            }
        }
    }

    public void Used()
    {
        if (!used)
        {
            used = true;
            sr.enabled = false;
        }
    }

    public void Return()
    {
        if (used)
        {
            used = false;
            sr.enabled = true;
        }
    }
}
