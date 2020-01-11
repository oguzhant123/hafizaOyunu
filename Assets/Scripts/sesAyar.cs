using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sesAyar : MonoBehaviour
{
    private AudioSource audiosrc;
    private float musicVolume = 1f;

    void Start()
    {
        audiosrc = GetComponent<AudioSource>();    
    }

    void Update()
    {
        audiosrc.volume = musicVolume;        
    }
    public void setVolume(float vol)
    {
        musicVolume = vol;
    }


}
