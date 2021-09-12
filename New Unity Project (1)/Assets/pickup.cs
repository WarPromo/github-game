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

            print("my position is: " + transform.position);

            picked.transform.position = new Vector2(transform.position.x, transform.position.y + 2);

            print("thieer position is: " + picked.transform.position + " " + picked.gameObject.name);

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

                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                Vector3 loc = worldPosition - picked.transform.position;
                loc = loc.normalized;
                //picked.transform.position = GetComponent<movement>().mySword.transform.position;
                picked.GetComponent<Rigidbody2D>().velocity = loc * -25;
                picked = null;


            }



        }
        
    }
}
