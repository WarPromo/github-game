using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
{
    // Start is called before the first frame update

    bool talking = false;
    GameObject talker = null;
    bool original = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (talking)
            {
                talker.GetComponent<chat>().interact();
                if (talker.GetComponent<chat>().finishedTalking)
                {
                    GetComponent<movement>().canmove = true;
                    GetComponent<movement>().focus = gameObject;
                    GetComponent<movement>().zoom = 6;
                    GetComponent<movement>().mySword.GetComponent<controlplayer>().enabled = original;
                    
                    talker.GetComponent<chat>().finishedTalking = false;
                    talker = null;
                    talking = false;
                    
                }
            }
            else
            {
                Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                List<Collider2D> overlaps = new List<Collider2D>();
                ContactFilter2D filter = new ContactFilter2D();
                filter.NoFilter();

                Physics2D.OverlapPoint(worldPosition, filter, overlaps);


                foreach(Collider2D overlap in overlaps)
                {
                    print(overlap);

                    if (overlaps != null && overlap.gameObject.tag == "talker")
                    {
                        talker = overlap.gameObject;
                        talking = true;
                        overlap.gameObject.GetComponent<chat>().interact();

                        GetComponent<movement>().canmove = false;
                        GetComponent<movement>().focus = talker;
                        GetComponent<movement>().zoom = talker.GetComponent<chat>().zoomAmount;
                        original = GetComponent<movement>().mySword.GetComponent<controlplayer>().enabled;
                        GetComponent<movement>().mySword.GetComponent<controlplayer>().enabled = false;
                        GetComponent<movement>().mySword.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        



                    }
                }




            }




        }
    }
}
