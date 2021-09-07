using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    // Start is called before the first frame update

    public bool autoScroll;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(autoScroll == true){
            transform.Translate(1,0,0);
        }
    }
}
