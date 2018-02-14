using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    //Define the ype of the item
    public int type = 0;
    //1 = Key red
    //2 = Key yellow
    //3 = Key blue
    //4 = Key green
    //5 = Coin

    public void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name=="Player" && collision.gameObject.GetComponent<Player>().canMove)
        {
            //Key
            if (type==1 || type==2 || type==3 || type==4)
            {
                Debug.Log("Got Key!");
                SingletonManager.Instance.key = type;
                Destroy(gameObject);
            }
            //Coin
            if (type==5)
            {
                Debug.Log("Got coin!");
                SingletonManager.Instance.coins += 1;
                Destroy(gameObject);
            }
        }
    }
}
