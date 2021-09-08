using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Vector3 checkPoint;
    public bool scrollType;

    public float respawnPoint = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3( checkPoint.x, checkPoint.y, -5 );
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.transform.position.x - transform.position.x > respawnPoint)
        {
            print("Respawn! Yuh");

            respawn();

            


        }
    }

    public void respawn()
    {
        transform.position = checkPoint;
        Camera.main.transform.position = new Vector3(checkPoint.x, checkPoint.y, -5);
        print("Respawn: " + scrollType);
        Camera.main.GetComponent<autoscroll>().doScroll = scrollType;
        Camera.main.GetComponent<autoscroll>().autoScroll = false;
    }
}
