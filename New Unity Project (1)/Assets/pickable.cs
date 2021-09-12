using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickable : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if ((transform.position - player.transform.position).magnitude < player.GetComponent<pickup>().distance)
            {
                if (player.GetComponent<pickup>().picked == null)
                {
                    player.GetComponent<pickup>().picked = gameObject;
                }
            }






        }
    }

}
