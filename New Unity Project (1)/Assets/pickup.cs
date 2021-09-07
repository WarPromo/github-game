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

        if (pickedUp)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            Vector3 loc = transform.position + ((worldPosition - transform.position).normalized) * d;
            Vector3 dV = loc - picked.transform.position;

            picked.GetComponent<Rigidbody2D>().velocity = dV * 5;

            
        }
        else
        {
            picked = null;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(pickedUp == false)
            {
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                Collider2D overlaps = Physics2D.OverlapPoint(worldPosition);

                if (overlaps != null && overlaps.gameObject.tag == "throwable")
                {
                    pickedUp = true;
                    picked = overlaps.gameObject;
                    d = (transform.position - worldPosition).magnitude;
                }
            }
            else
            {
                pickedUp = false;
            }



        }
    }
}
