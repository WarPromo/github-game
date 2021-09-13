using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject tpspot;
    GameObject p;
    public Camera c;

    bool teleporting = false;
    bool canteleport = false;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canteleport)
        {
           
            StartCoroutine(teleportDelay());
            canteleport = false;
        }
        if (teleporting)
        {
            p.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    IEnumerator teleportDelay()
    {
        print("TELEPORTING");

        //mainCamera.transform.position = new Vector2( tpspot.transform.position.x, tpspot.transform.position.y);



        teleporting = true;
        yield return new WaitForSeconds(0.5f);
        Camera current = p.GetComponent<movement>().mainCamera;
        c.gameObject.SetActive(true);
        p.GetComponent<movement>().zoom = c.orthographicSize;
        p.GetComponent<movement>().mainCamera = c;
        current.gameObject.SetActive(false);

        p.transform.position = new Vector3(tpspot.transform.position.x, tpspot.transform.position.y, p.transform.position.z);
        teleporting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (teleporting == true) return;
        print("calling");
        if(collision.gameObject.tag == "Player")
        {
            canteleport = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (teleporting == true) return;
        if (collision.gameObject.tag == "Player")
        {
            canteleport = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (teleporting == true) return;
        print("calling");
        if (collision.gameObject.tag == "Player")
        {
            canteleport = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (teleporting == true) return;
        if (collision.gameObject.tag == "Player")
        {
            canteleport = false;
        }
    }
}
