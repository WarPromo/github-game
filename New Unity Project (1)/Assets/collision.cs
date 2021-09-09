using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject parent;
    public float angle;
    public GameObject player;
    public GameObject pickedup;

    bool collided = false;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), parent.GetComponent<controlplayer>().player.GetComponent<Collider2D>());
        player = parent.GetComponent<controlplayer>().player;
    }

    // Update is called once per frame
    void Update()
    {
        pickedup = player.GetComponent<pickup>().picked;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGER! ");

        if (collision.gameObject.GetComponent<nocollide>() != null) return;
        if (collision.gameObject == pickedup) return;

        parent.GetComponent<controlplayer>().directionAngle = angle;
        parent.GetComponent<controlplayer>().enables -= 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<nocollide>() != null) return;
        if (collision.gameObject == pickedup) return;
        print("EXITED TRIGGER! ");
        parent.GetComponent<controlplayer>().enables += 1;

    }
}
