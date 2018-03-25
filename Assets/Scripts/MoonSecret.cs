using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSecret : MonoBehaviour
{
    public AudioSource Music;

    // Use this for initialization
    void Start()
    {
        AudioSource Music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Music.Play();
        }
    }
}
