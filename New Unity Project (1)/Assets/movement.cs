using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float acceleration;
    public float maxspeed;

    public bool canjump = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKey(KeyCode.W))
        {
            v.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            v.y += -1;
        }

      


        float dx = velocity.x + ((maxspeed * v.x) - velocity.x) * acceleration;
        //float dy = velocity.y + ((maxspeed * v.y) - velocity.y) * acceleration;

        newVelocity.x = dx;
        //newVelocity.y = dy;

        GetComponent<Rigidbody2D>().velocity = newVelocity;

        canjump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canjump = true;
        }
    }
}
