using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerabutton : MonoBehaviour {

    public bool used = false;

    private SpriteRenderer sr;
    public Sprite button1;
    public Sprite button2;

    private void Start()
    {
        //Get renderer
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //See if collided with player
        if (collision.gameObject.name == "Player" && collision.gameObject.GetComponent<Player>().canMove && !used)
        {
            Used();
            //All lasers
            Cameralight[] allLights = FindObjectsOfType<Cameralight>();
            foreach (Cameralight cam in allLights)
            {
                cam.Open();
            }
        }
    }

    public void Used()
    {
        used = true;
        sr.sprite = button2;
    }

    public void ResetButton()
    {
        used = false;
        sr.sprite = button1;
    }
}
