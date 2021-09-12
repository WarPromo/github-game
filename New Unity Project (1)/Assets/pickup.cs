using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update

    bool pickedUp = false;
    public GameObject picked;
    float d = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(picked != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), picked.GetComponent<Collider2D>());
            picked.transform.position = transform.position;
        }



        if (Input.GetKeyDown(KeyCode.E))
        {




            if(picked != null)
            {
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                Vector3 loc = worldPosition - picked.transform.position;
                loc = loc.normalized;
                picked.transform.position = GetComponent<movement>().mySword.transform.position;
                picked.GetComponent<Rigidbody2D>().velocity = loc * 5;
                picked = null;


            }



        }
    }
}
