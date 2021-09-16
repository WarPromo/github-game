using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablehat : MonoBehaviour
{

    public GameObject hat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<chat>().finishedTalkingAgo == 0 || GetComponent<chat>().finishedTalkingAgo == 1)
        {

            hat.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
