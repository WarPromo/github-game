using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityobject : MonoBehaviour
{

    public float gravityMultiply = 2;
    Dictionary<GameObject, float> gravities = new Dictionary<GameObject, float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Rigidbody2D rig) == false) return;

        float gravity = collision.GetComponent<Rigidbody2D>().gravityScale;
        GameObject g = collision.gameObject;

        gravities.Add(g, gravity);

        collision.GetComponent<Rigidbody2D>().gravityScale *= gravityMultiply;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gravities.ContainsKey(collision.gameObject))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = gravities[collision.gameObject];
            gravities.Remove(collision.gameObject);
        }
    }
}
