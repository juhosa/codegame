using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int coins = 0;
    public int key = 0;
    public bool running = false;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
