using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoscroll : MonoBehaviour
{
    public bool autoScroll = false;
    public bool doScroll = false;

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
            Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.x = velocity.x +  (scrollSpeed - velocity.x) * 0.01f;
            print(velocity);
            GetComponent<Rigidbody2D>().velocity = velocity;
        
        }
    }
}
