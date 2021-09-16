using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update

    bool pickedUp = false;
    public GameObject picked = null;
    public float distance = 2f;
    float d = 0;

    int nullCounter = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (picked != null)
        {
            nullCounter++;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), picked.GetComponent<Collider2D>());
            float z = picked.transform.position.z;



            picked.transform.position = new Vector2(transform.position.x, transform.position.y + 2);



        }
        else
        {
            nullCounter = 0;
        }


        
        if (Input.GetKeyDown(KeyCode.F))
        {




            if(nullCounter > 5)
            {

                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), picked.GetComponent<Collider2D>(), false);

                //picked.transform.position = GetComponent<movement>().mySword.transform.position;
                picked.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * 10;
                picked = null;


            }



        }
        
    }
}
