using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : Singleton<SingletonManager> {

    protected SingletonManager() { }

    public int key = 0;
    public int coins = 0;
}
