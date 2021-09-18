using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update

    public bool buttonPressed = false;
    bool pressing = false;
    float notPressed = 0;
    Vector2 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (pressing)
        {
            notPressed = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1500f * Time.deltaTime);
        }
        else
        {
            notPressed+=Time.deltaTime;
        }

        if(notPressed > 0.3f && startPos.y > transform.position.y)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2000f * Time.deltaTime);
        }
        else if (notPressed > 0.3f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "buttonactivator")
        {
            buttonPressed = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressing = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressing = false;
        }
    }


}
