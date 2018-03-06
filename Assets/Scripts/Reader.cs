using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour {

    private float speed=2f;
    private float rayLength = 0.01f;
    public LayerMask codeBlockLayer;

    private Player playerObject;

    public float posDifference;
    private Vector2 startpo;

    //Array to store loop positions in
    public Vector2[] loopPositions;

    //Codeblock sprites
    public Sprite[] codeBlockSprite;

    private void Start()
    {
        
        //Get player to do actions for him
        GameObject player = GameObject.Find("/Grid/Player");
        playerObject = player.GetComponent<Player>();
    }

    private void Update()
    {
        //Get startpo each frame since it's the parent's startpo
        startpo = transform.parent.transform.position;
        //Move to the right
        transform.position = new Vector2(transform.position.x+(speed * Time.deltaTime), transform.position.y);

        //Raycast and see collisions with block
        Vector2 orig = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D ray = Physics2D.Raycast(orig, Vector2.right, rayLength, codeBlockLayer);
        Debug.DrawRay(orig, Vector2.right * rayLength, Color.green);
        CodeBase rayCodebase = ray.collider.gameObject.GetComponent<CodeBase>();

        if (ray && !rayCodebase.used && rayCodebase.HasSprite())
        {
            //Make player do actions corresponding the codebase
            if (rayCodebase.GetSprite()== codeBlockSprite[0])
            {
                StartCoroutine(rayCodebase.UsedWait());
                playerObject.MoveForward();
            }
            if (rayCodebase.GetSprite() == codeBlockSprite[1])
            {
                StartCoroutine(rayCodebase.UsedWait());
                playerObject.RotateRight();
            }
            if (rayCodebase.GetSprite() == codeBlockSprite[2])
            {
                StartCoroutine(rayCodebase.UsedWait());
                playerObject.RotateLeft();
            }
            if (rayCodebase.GetSprite() == codeBlockSprite[3])
            {
                StartCoroutine(rayCodebase.UsedWait());
                playerObject.MoveBackward();
            }
            if (rayCodebase.GetSprite() == codeBlockSprite[4])
            {
                StartCoroutine(rayCodebase.UsedWait());
                playerObject.JumpForward();
            }

            //React to loop blocks
            if (rayCodebase.blockId == 2)
            {
                rayCodebase.used = true;
                loopPositions[rayCodebase.currentSprite] = rayCodebase.transform.position;
            }
            if (rayCodebase.blockId == 1)
            {
                rayCodebase.used = true;
                transform.position = loopPositions[rayCodebase.currentSprite];
            }
        }

        //Destroy reader if over the last codebase
        if (transform.position.x > (startpo.x+posDifference))
        {
            GameManager.instance.running = false;
            //Reset all codebases so they can be used again
            CodeBase[] allObjects = FindObjectsOfType<CodeBase>();
            foreach (CodeBase cb in allObjects)
            {
                cb.used = false;
            }

            Destroy(gameObject);
        }
    }
}
