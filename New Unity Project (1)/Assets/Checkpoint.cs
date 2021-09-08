using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Vector3 checkPoint;
    public bool scrollType;

    public GameObject red;

    public float respawnPoint = 5.0f;

    public float respawnScroll = 0f;
    public float scrollSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3( checkPoint.x, checkPoint.y, -5 );
        
    }

    // Update is called once per frame
    void Update()
    {

        red.GetComponent<Rigidbody2D>().velocity = new Vector2(scrollSpeed, 0);

        Vector3 pos = red.transform.position;
        pos.y = Camera.main.transform.position.y;
        red.transform.position = pos;

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "scrolldeath")
        {
            print("Respawn! Yuh");

            respawn();
        }
    }


    public void respawn()
    {
        transform.position = checkPoint;
        Camera.main.transform.position = new Vector3(checkPoint.x, checkPoint.y, -5);
        print("Respawn: " + scrollType);
        scrollSpeed = respawnScroll;

        float width = red.GetComponent<SpriteRenderer>().bounds.size.x;

        Vector3 pos = Camera.main.transform.position;
        pos.z = -2;
        pos.x -= respawnPoint + width / 2;
        red.transform.position = pos;
    }
}
