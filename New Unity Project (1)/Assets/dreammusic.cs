using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dreammusic : MonoBehaviour
{
    // Start is called before the first frame update

    public int picktime = 0;
    public AudioSource dream;

    void Start()
    {
        dream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<pickup>().picked == gameObject)
        {
            picktime++;
        }

        if (picktime == 1)
        {
            print("playing dweem speedrunner song");
            dream.Play(100);
        }
        if(player.GetComponent<movement>().mainCamera != null && player.GetComponent<movement>().mainCamera != Camera.main)
        {
            dream.Stop();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.TryGetComponent( out teleportOriginal script))
        {
            if(script.theobject == gameObject)
            {
                dream.Stop();
                picktime = 0;
            }
        }
    }
}
