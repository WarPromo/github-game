using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class savenload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(Directory.GetCurrentDirectory());
        System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "/" + "bruh.txt", "glutenberg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
