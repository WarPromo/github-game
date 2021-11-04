using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setca : MonoBehaviour
{

    public Camera c;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<movement>().mainCamera != c)
            {
                GameObject p = collision.gameObject;
                Camera current = p.GetComponent<movement>().mainCamera;
                c.gameObject.SetActive(true);
                p.GetComponent<movement>().zoom = c.orthographicSize;
                p.GetComponent<movement>().mainCamera = c;
                current.gameObject.SetActive(false);
            }
        }
    }
}
