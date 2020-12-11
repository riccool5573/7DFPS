using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class MusicPlayer : MonoBehaviour
{
     AudioClip song;
     AudioClip loop;
    AudioSource aS;
    bool first=true;
    // Start is called before the first frame update
    void Start()
    {
        song = Resources.Load<AudioClip>("Sounds/Song");
        loop = Resources.Load<AudioClip>("Sounds/SongLoop");
        aS = GetComponent<AudioSource>();
        aS.clip = song;
        aS.Play();
        aS.loop = false;
        aS.time = aS.clip.length - 5;
    }

    // Update is called once per frame
    void Update()
    {
       if( aS.time== aS.clip.length&&first)
        {
            aS.time = 0;
            aS.clip = loop;
            aS.loop = true;
            aS.Play();
            first = false;
        }
    }
}
