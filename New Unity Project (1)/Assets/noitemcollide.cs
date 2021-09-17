using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noitemcollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("throwable");

        for(int a = 0; a < objects.Length; a++)
        {
            Physics2D.IgnoreCollision(objects[a].GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
