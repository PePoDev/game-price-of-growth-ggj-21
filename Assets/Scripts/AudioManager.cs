using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip open;

    private Transform _cameraPosition;

    private void Start()
    {
        _cameraPosition = Camera.main.transform;
    }

    public void PlaySound(string soundName)
    {
        AudioClip sound;
        switch (soundName)
        {
            case "open":
                sound = open;
                break;
            default:
                sound = open;
                break;
        }

        AudioSource.PlayClipAtPoint(sound, _cameraPosition.position);
    }
}