using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    //Define the ype of the item
    public int type = 0;
    public GameObject[] locks;
    //1 = Key
    //2 = Coin

    public void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name=="Player" && collision.gameObject.GetComponent<Player>().canMove)
        {
            //Key
            if (type==1)
            {
                Debug.Log("Got Key!");
                foreach (GameObject l in locks)
                {
                    l.GetComponent<Lock>().Open();
                }
                Destroy(gameObject);
            }
            //Coin
            if (type==2)
            {
                Debug.Log("Got coin!");
                GameManager.instance.coins += 1;
                Destroy(gameObject);
            }
        }
    }
}
