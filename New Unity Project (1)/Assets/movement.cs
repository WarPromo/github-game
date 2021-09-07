using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float acceleration;
    public float maxspeed;

    bool canjump = false;
    public float jumpheight;

    public float outrunPoint = 0;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 cameraDist = -Camera.main.transform.position + transform.position;
        Vector2 cvelocity = Camera.main.GetComponent<Rigidbody2D>().velocity;
        Vector2 cvelocity2 = cvelocity;

        if (Camera.main.GetComponent<autoscroll>().doScroll)
        {
            Camera.main.GetComponent<autoscroll>().autoScroll = !(cameraDist.x > outrunPoint);
        }
        



        if (Camera.main.GetComponent<autoscroll>().autoScroll == false && !Camera.main.GetComponent<autoscroll>().doScroll)
        {
            cvelocity = cameraDist * 10;
        }
        else if (Camera.main.GetComponent<autoscroll>().doScroll && !Camera.main.GetComponent<autoscroll>().autoScroll)
        {
            cvelocity.y = cameraDist.y * 10;
            cvelocity.x = cvelocity.x + ( (maxspeed*1.5f) - cvelocity.x)*0.01f;
        }
        else
        {
            cvelocity.y = cameraDist.y * 10;
          
        }
        

        Camera.main.GetComponent<Rigidbody2D>().velocity = cvelocity;


        Vector2 v = new Vector2(0, 0);
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        Vector2 newVelocity = new Vector2(0, velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            v.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            v.x += 1;
        }

        if(canjump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            print("Jumped");
            newVelocity.y = jumpheight;
        }

      


        float dx = velocity.x + ((maxspeed * v.x) - velocity.x) * acceleration;

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
