using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostArrows : MonoBehaviour {

    public int dir = 0;
    //0=up
    //1=right
    //2=down
    //3=left
    public Reader reader;

    private void Start()
    {

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Player>().canMove)
        {
            //Get reader
            GameObject readerObject = GameObject.Find("BaseReader(Clone)");
            if (readerObject != null)
            {
                reader = readerObject.GetComponent<Reader>();
                reader.wait = true;
            }
            //Move player
            if (dir == 0)
            {
                collision.gameObject.GetComponent<Player>().MoveUp();
            }
        }
    }
}
