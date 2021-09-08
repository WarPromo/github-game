using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float acceleration;
    public float maxspeed;

    bool canjump = false;
    public bool canmove = true;
    public float jumpheight;

    public float outrunPoint = 0;

    public GameObject focus;
    public GameObject mySword;

    public float zoom;
    

    void Start()
    {
        focus = gameObject;
        zoom = 6;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 cameraDist = -Camera.main.transform.position + focus.transform.position;
        Vector2 cvelocity = Camera.main.GetComponent<Rigidbody2D>().velocity;
        Vector2 cvelocity2 = cvelocity;

        Camera.main.GetComponent<Rigidbody2D>().velocity = cameraDist * 10;
        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, zoom, Time.deltaTime);


        Vector2 v = new Vector2(0, 0);
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 newVelocity = new Vector2(0, velocity.y);
        if (canmove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                v.x += -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                v.x += 1;
            }
            if (canjump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
            {
                print("Jumped");
                newVelocity.y = jumpheight;
            }
        }




      


        float dx = velocity.x + ((maxspeed * v.x) - velocity.x) * acceleration * Time.deltaTime;

        newVelocity.x = dx;
        //newVelocity.y = dy;

        GetComponent<Rigidbody2D>().velocity = newVelocity;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canjump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canjump = false;
        }
    }
}
