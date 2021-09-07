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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (parent.GetComponent<controlplayer>().throwing && collided == false && collision.gameObject.tag != "swordtriggerer")
        {

            GameObject inverser = Instantiate( GameObject.FindGameObjectWithTag("inverser") );
            inverser.tag = "Untagged";
            Vector3 parentTrans = collision.gameObject.transform.localScale;

            parent.GetComponent<Rigidbody2D>().isKinematic = true;
            parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            inverser.transform.SetParent(collision.gameObject.transform);
            inverser.transform.localScale = new Vector3(1 / parentTrans.x, 1 / parentTrans.y, 1 / parentTrans.z);




            inverser.transform.Rotate(0, 0, collision.gameObject.transform.eulerAngles.z);

            parent.transform.SetParent(inverser.transform);

            collided = true;


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGER! ");

        if (collision.gameObject == pickedup) return;

        parent.GetComponent<controlplayer>().directionAngle = angle;
        parent.GetComponent<controlplayer>().enables -= 1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == pickedup) return;
        print("EXITED TRIGGER! ");
        parent.GetComponent<controlplayer>().enables += 1;

    }
}
