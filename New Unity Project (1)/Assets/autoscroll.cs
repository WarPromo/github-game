using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscroll : MonoBehaviour
{
    public bool autoScroll = false;

    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (autoScroll)
        {
            transform.Translate(scrollSpeed, 0, 0);
        }
    }
}
