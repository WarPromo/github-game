using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject parent;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), parent.GetComponent<controlplayer>().player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGER! ");
        parent.GetComponent<controlplayer>().directionAngle = angle;
        parent.GetComponent<controlplayer>().enables -= 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("EXITED TRIGGER! ");
        parent.GetComponent<controlplayer>().enables += 1;

    }
}
