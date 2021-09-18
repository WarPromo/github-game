using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject reset;
    Vector3 teleportPos;

    void Start()
    {
        teleportPos = reset.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<button>().buttonPressed)
        {
            reset.transform.position = teleportPos;
            GetComponent<button>().buttonPressed = false;
        }
    }
}
