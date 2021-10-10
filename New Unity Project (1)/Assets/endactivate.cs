using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endactivate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject border;
    public GameObject endfocus;
    public GameObject holder;
    public float zoomout;
    public float yValue;
    bool ended = false;
    

    AudioSource endMusic;

    void Start()
    {
        endMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().mainCamera.gameObject.name == "Level 2 Teleport" && !endMusic.isPlaying)
        {
            print("PLAY END MUSIC");
            endMusic.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !ended)
        {
            GameObject p = collision.gameObject;
            Vector3 pos = border.transform.position;
            pos.y = yValue;
            border.transform.position = pos;
            endMusic.volume = 0.2f;
            ended = true;
            movement m = p.GetComponent<movement>();
            m.focus = endfocus;
            m.zoom = zoomout;
            m.cameraSpeed = 0.3f;
            holder.active = false;
        }
    }
}
