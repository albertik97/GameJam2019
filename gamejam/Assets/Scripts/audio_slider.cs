using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class audio_slider : MonoBehaviour
{
    private AudioSource audio;

    private float volume = 1f;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = volume;
    }

    void Update()
    {
        audio.volume = volume; 
    }

    public void SetVolume(Slider slider)
    {
        volume = slider.value;
    }
}
