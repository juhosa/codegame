using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour {

    //Define required key type
    public int keyRequired = 0;
    //1 = Key red
    //2 = Key yellow
    //3 = Key blue
    //4 = Key green

    private void Update()
    {
        if (SingletonManager.Instance.key==keyRequired)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, transform.localScale.z - 0.05f);
            }
        }
    }
}
