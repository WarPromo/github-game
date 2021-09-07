using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainb : MonoBehaviour
{
    SpriteRenderer renderer;


    int n = 1;
    int m = 1;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int b = n % 3;
        float[] c = { renderer.color.r, renderer.color.g, renderer.color.b };

        if(m == 1 && c[b] >= 1)
        {
            n++;
            b = n % 3;
            if (c[b] >= 1) m = -1;
            if (c[b] <= 0) m = 1;
        }
        if (m == -1 && c[b] <= 0)
        {
            n++;
            b = n % 3;
            if (c[b] >= 1) m = -1;
            if (c[b] <= 0) m = 1;


        }



        c[b] += Time.deltaTime * m;



        renderer.color = new Color(c[0], c[1], c[2]);

      
    }
}
