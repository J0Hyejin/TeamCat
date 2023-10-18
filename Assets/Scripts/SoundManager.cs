using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;

    public void SetMusicVolume(float vloume)
    {
        musicsource.volume = vloume;
    }
}
