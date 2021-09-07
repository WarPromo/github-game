using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollbutton : MonoBehaviour
{
    bool buttonpressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
        if(collision.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
        if(collision.gameObject.tag == "buttonactivator")
        {
            print("START AUTO SCROLL");
            buttonpressed = true;
            Camera.main.GetComponent<Autoscroll>().autoScroll = true;
        }
    }
}
