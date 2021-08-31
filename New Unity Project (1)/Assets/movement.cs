using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            v.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            v.x += 1;
        }
        print(v);
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
