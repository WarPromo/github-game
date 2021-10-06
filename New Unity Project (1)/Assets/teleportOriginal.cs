using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportOriginal : MonoBehaviour
{


    public GameObject theobject;
    Vector3 originalPos;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        originalPos = theobject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == theobject)
        {
            dropItem();
            theobject.transform.position = originalPos;
            if (theobject.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == theobject)
        {
            dropItem();
            theobject.transform.position = originalPos;
            if (theobject.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void dropItem()
    {
        if(player.GetComponent<pickup>().picked == theobject)
        {
            player.GetComponent<pickup>().picked = null;
        }
    }
}
