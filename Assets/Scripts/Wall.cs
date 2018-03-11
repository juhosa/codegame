using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
}
