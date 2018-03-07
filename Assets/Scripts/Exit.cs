using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public int keysNeeded;
    private bool opened;

    private Animator anim;
    private BoxCollider2D bc2d;
    private Player playerObject;

    private void Start()
    {
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
        if (opened && playerObject.transform.position == transform.position)
        {
            GameManager.instance.levelCompleted = true;
        }
    }
}
