using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class savenload : MonoBehaviour
{
    // Start is called before the first frame update
    int t = 1;
    public bool gameEnded = false;


    void Start()
    {

        loadSaveFile();
    }

    // Update is called once per frame
    void Update()
    {

        t++;
        if (t % 100 == 0)
        {
            if (gameEnded)
            {
                writeRandomShit();
                return;
            }
            saveData();
        }
    }

    public void writeRandomShit()
    {
        File.WriteAllText(Directory.GetCurrentDirectory() + "/bruh.txt", "game ended");
    }

    public void loadSaveFile()
    {
        string data = File.ReadAllText(Directory.GetCurrentDirectory() + "/bruh.txt");
        string[] dataArr = data.Split('|');


        try
        {
            string[] posStringArr = dataArr[0].Split(':')[1].Split(' ');
            Vector3 pos = new Vector3(float.Parse(posStringArr[0]), float.Parse(posStringArr[1]), float.Parse(posStringArr[2]));

            print("HERE: " + pos);

            transform.position = new Vector3(pos.x, pos.y, pos.z);


            string pickedData = dataArr[1].Split(':')[1];

            if (pickedData != "null")
            {
                string[] pickedArr = dataArr[1].Split(':')[1].Split(' ');
                string id = pickedArr[0];
                GameObject picked = null;
                GameObject[] objects = GameObject.FindGameObjectsWithTag("throwable");

                print("ID: " + id);

                for (int a = 0; a < objects.Length; a++)
                {
                    if (objects[a].GetComponent<pickable>().id.Equals(id))
                    {
                        print("setting picked");
                        picked = objects[a];
                        break;
                    }
                }
                GetComponent<pickup>().picked = picked;
            }

            string swordData = dataArr[2].Split(':')[1];
            GameObject sword = GameObject.FindGameObjectWithTag("swordtriggerer");

            if (swordData == "true")
            {
                sword.GetComponent<controlplayer>().enabled = true;
            }
        }
        catch(System.Exception e)
        {
            print("save file broken");
        }


    }

    public void saveData()
    {
        string data = "";

        Vector3 myPosition = gameObject.transform.position;

        data += "playerPosition:" + myPosition.x + " " + myPosition.y + " " + myPosition.z;
        data += "|";

        pickup pickUp = GetComponent<pickup>();

        if (pickUp.picked != null && pickUp.picked.GetComponent<pickable>().id != null) print("they'e holding something");

        if(pickUp.picked != null && pickUp.picked.GetComponent<pickable>().id != null)
        {
            GameObject picked = pickUp.picked;
            Vector3 pos = picked.transform.position;
            data += "currentlyPicked:" + pickUp.picked.GetComponent<pickable>().id + " " + pos.x + " " + pos.y + " " + pos.z;
        }
        else
        {
            data += "currentlyPicked:null";
        }
        data += "|";

        GameObject sword = GameObject.FindGameObjectWithTag("swordtriggerer");

        if(sword.GetComponent<controlplayer>().enabled == false)
        {
            data += "hasSword:false";
        }
        else
        {
            data += "hasSword:true";
        }

        if(File.Exists(Directory.GetCurrentDirectory() + "/bruh.txt") == false)
        {
            print("Making it");
            
            File.CreateText(Directory.GetCurrentDirectory() + "/bruh.txt");
        }

        File.WriteAllText(Directory.GetCurrentDirectory() + "/bruh.txt", data);

    }
}
