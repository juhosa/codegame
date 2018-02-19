using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBaseRow : MonoBehaviour {

    private Vector3 startpo;
    private float speed = 3f;

    public int rowSize = 1;
    public CodeBase basePrefab;

    private void Start()
    {
        startpo = transform.position;

        for (int i=0; i<=rowSize; i++)
        {
            Vector2 posR = new Vector2(transform.position.x+(i*0.32f), transform.position.y);
            CodeBase basR = Instantiate(basePrefab, posR, Quaternion.identity);
            basR.transform.parent = transform;
            /*
            Vector2 posL = new Vector2(transform.position.x - (i * 0.32f), transform.position.y);
            CodeBase basL = Instantiate(basePrefab, posL, Quaternion.identity);
            basL.transform.parent = transform;
            */
        }
    }

    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
