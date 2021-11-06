using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showpaper : MonoBehaviour
{

    public int element;
    public GameObject canvasImage;
    public AudioSource audio;
    int lastN = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        print(element + " " + GetComponent<chat>().n);

        if(GetComponent<chat>().n % GetComponent<chat>().texts.Length == element)
        {
            print("WE MAKIN IT VISIBLEN IGGA!");
            canvasImage.SetActive(true);
            if(lastN != GetComponent<chat>().n) audio.Play(0);
        }
        else
        {
            canvasImage.SetActive(false);
        }
        lastN = GetComponent<chat>().n;
    }
}
