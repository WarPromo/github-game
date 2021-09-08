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




        if (!followPlayer)
        {

            if (!GetComponent<Rigidbody2D>().isKinematic && throwing)
            {
                GetComponent<Collider2D>().isTrigger = false;
                GetComponent<Rigidbody2D>().velocity = throwVelocity;
            }
        }
        else
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

        if (Input.GetMouseButton(0) && ( throwing == false && followPlayer == true ))
        {



            print(transform.rotation.z);

            float angle = transform.rotation.eulerAngles.z * Mathf.PI / 180;
            angle += Mathf.PI;

            throwVelocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            throwVelocity *= 5;



            throwing = true;
            followPlayer = false;

            StartCoroutine(makeCopy());


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

    private void OnCollisionStay2D(Collision2D collision)
    {


        if (GetComponent<controlplayer>().throwing && collision.gameObject.tag != "swordtriggerer")
        {

            print("HIT SOMETHING!!!!!!");

            GameObject inverser = Instantiate(GameObject.FindGameObjectWithTag("inverser"));
            inverser.tag = "Untagged";
            Vector3 parentTrans = collision.gameObject.transform.localScale;

            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<controlplayer>().throwing = false;

            inverser.transform.SetParent(collision.gameObject.transform);
            inverser.transform.localScale = new Vector3(1 / parentTrans.x, 1 / parentTrans.y, 1 / parentTrans.z);




            inverser.transform.Rotate(0, 0, collision.gameObject.transform.eulerAngles.z);

            transform.SetParent(inverser.transform);




        }
    }

}
