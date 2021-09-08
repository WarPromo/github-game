using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chat : MonoBehaviour
{
    // Start is called before the first frame update



    GameObject textObject;


    public string[] texts;
    public bool finishedTalking = false;
    public float zoomAmount;
    int n = 0;
    
    void Start()
    {
        textObject = transform.GetChild(0).GetChild(0).gameObject;
        textObject.GetComponent<Text>().text = texts[n % texts.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interact()
    {

        n++;

        if(n % texts.Length == 0)
        {
            finishedTalking = true;
        }

        textObject.GetComponent<Text>().text = texts[n % texts.Length].Replace("/n", System.Environment.NewLine);

    }
}