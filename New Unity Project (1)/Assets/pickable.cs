using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickable : MonoBehaviour
{
    // Start is called before the first frame update
    int throwable = 0;
    public string id;


    void Start()
    {
        
    }

    public void setThrowable()
    {
        throwable = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (throwable > 0) throwable--;

        if (Input.GetKeyDown(KeyCode.F) && throwable == 0)
        {
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");


            Vector2 d = (transform.position - player.transform.position);

            if (d.magnitude < player.GetComponent<pickup>().distance)
            {

                if (player.GetComponent<pickup>().picked == null)
                {
                    player.GetComponent<pickup>().picked = gameObject;
                }
            }






        }
    }

}
