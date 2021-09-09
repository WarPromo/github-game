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

    public bool throwing = false;

    Vector2 throwVelocity = new Vector2(0, 0);

    GameObject copyThrow = null;

    bool followPlayer = true;




    void Start()
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown > 0) cooldown -= 0;

        Vector2 ang = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z) - transform.position;

        float angle = Mathf.Atan2(ang.y, ang.x) * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        GetComponent<Rigidbody2D>().velocity = moveSpeed * GetTarget();

        if (directionAngle != null && isenabled && cooldown == 0)
        {
            double radians = ((float)directionAngle + angle) * Mathf.PI / 180;
            double x = Mathf.Cos((float)radians);
            double y = Mathf.Sin((float)radians);

            Vector2 v = new Vector2((float)x, (float)y) * 20;
            player.GetComponent<Rigidbody2D>().velocity = v;

            cooldown = cooldownLength;

            isenabled = false;
        }

        if (directionAngle != null) directionAngle = null;

        if (enables == 1)
        {
            isenabled = true;
        }



    }

    IEnumerator makeCopy()
    {
        yield return new WaitForSeconds(0.5f);
        copyThrow = Instantiate(gameObject);

        copyThrow.GetComponent<Rigidbody2D>().isKinematic = false;
        copyThrow.GetComponent<Collider2D>().isTrigger = true;
        copyThrow.GetComponent<controlplayer>().throwing = false;
        copyThrow.GetComponent<controlplayer>().enables = 1;
        copyThrow.transform.position = transform.position + new Vector3(GetTarget().x, GetTarget().y, 0 ) ;




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
