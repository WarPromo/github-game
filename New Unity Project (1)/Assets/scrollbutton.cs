using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollbutton : MonoBehaviour
{
    bool buttonpressed = false;
    public GameObject wall;
    public float scrollSpeed = 1.0f;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();

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
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
        }
        if(collision.gameObject.tag == "buttonactivator")
        {
            print("START AUTO SCROLL");
            buttonpressed = true;
            StartCoroutine(startScroll());
        }
    }

    IEnumerator startScroll()
    {

        audioData.Play(0);

        wall.AddComponent<Rigidbody2D>();
        wall.tag = "ground";
        wall.GetComponent<Rigidbody2D>().AddForce(new Vector2(80, 500));
        yield return new WaitForSeconds(1);

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Checkpoint>().respawnScroll = scrollSpeed;
        player.GetComponent<Checkpoint>().scrollSpeed = scrollSpeed;

        


    }
}
