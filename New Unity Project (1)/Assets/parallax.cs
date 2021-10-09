using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject relative;
    Vector3 pos;
    Vector3 originalD;
    float originalZ;
    public float moveAmount = 5;
    // Start is called before the first frame update
    void Start()
    {
        pos = relative.transform.position;
        originalD = pos-transform.position;
        originalZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bru = Camera.current.transform.position + ( originalD + (pos - relative.transform.position) );
        Vector3 real = new Vector3(bru.x, bru.y, originalZ);
    }
}
