using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{

    public Vector2 point1;
    public Vector2 point2;

    public float speed;

    Vector2 goTowards;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        goTowards = point2;
        transform.position = point1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2T = new Vector2(transform.position.x, transform.position.y);
        Vector2 future = new Vector2(transform.position.x, transform.position.y) + move*Time.deltaTime;
        Vector2 fD = goTowards - future;
        Vector2 nD = goTowards - v2T;


        if( (fD.x > 0 && nD.x < 0) || (fD.x < 0 && nD.x > 0))
        {

            if (goTowards == point1)
            {
                goTowards = point2;
                transform.position = point1;
            }
            else
            {
                goTowards = point1;
                transform.position = point2;
            }
        }


        
        move = (goTowards - v2T);
        move = move.normalized * speed;

        transform.Translate(move * Time.deltaTime);
    }
}
