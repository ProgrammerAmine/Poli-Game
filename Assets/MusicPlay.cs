using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    AudioSource source;
    void Awake() {
    source = GetComponent<AudioSource>();
    }

    void Start()
    {
        source.Play();
    }
}

