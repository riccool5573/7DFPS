using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whizz : MonoBehaviour
{
    AudioSource aS;
    AudioClip[] clips;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
        clips = Resources.LoadAll<AudioClip>("Sounds/Effects");
    }
    private void Update()
    {
        if (!aS.isPlaying &&Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 1.5f)
        {
            aS.PlayOneShot(clips[Mathf.FloorToInt(Random.Range(1, 10))]);
        }
    }
}
