using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class givesword : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audiosource;

    bool gaveSword = false;




    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gaveSword) return;

        if (GetComponent<chat>().finishedTalkingAgo == 0 || GetComponent<chat>().finishedTalkingAgo == 1)
        {
            print("finished");
            audiosource.Play(0);
            gaveSword = true;
        }
    }
}
