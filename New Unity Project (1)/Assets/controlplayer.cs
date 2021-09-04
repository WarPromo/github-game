using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlplayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update

    Vector2 lastMousePos = new Vector2(0, 0);
    Vector2 currentMousePos = new Vector2(0, 0);

    public float maxSwingD;

    public int cooldownLength;

    public float moveSpeed;

    public int enables = 2;
    int cooldown = 0;
    public float? directionAngle = null;
    bool isenabled = false;




    void Start()
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {


        if (cooldown > 0) cooldown -= 0;

        Vector2 ang = player.transform.position - transform.position;

        float angle = Mathf.Atan2(ang.y, ang.x)* 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        GetComponent<Rigidbody2D>().velocity = moveSpeed * GetTarget();

        if(directionAngle != null && isenabled && cooldown == 0)
        {
            double radians = ((float)directionAngle + angle) * Mathf.PI / 180;
            double x = Mathf.Cos((float)radians);
            double y = Mathf.Sin((float)radians);

            Vector2 v = new Vector2((float)x, (float)y) * 20;
            player.GetComponent<Rigidbody2D>().velocity = v;

            cooldown = cooldownLength;

            isenabled = false;
        }

        if(directionAngle != null) directionAngle = null;

        if (enables == 3)
        {
            isenabled = true;
        }



    }


    public Vector2 GetTarget()
    {
 
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        lastMousePos = currentMousePos;
        currentMousePos = worldPosition;

        Vector3 pos = player.transform.position;
        Vector3 dpos = new Vector3(worldPosition.x, worldPosition.y) - pos;




        float d = dpos.magnitude;

        if (d > maxSwingD) d = maxSwingD;

        dpos = dpos.normalized;
        dpos.x *= d;
        dpos.y *= d;

        Vector2 target = (player.transform.position + dpos) - transform.position;

        return target;
    }

}
