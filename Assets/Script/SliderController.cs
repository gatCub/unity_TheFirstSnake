using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audio;

    void Start()
    {
        if (PlayerPrefs.HasKey("SliderVolume"))
        {
            slider.value = PlayerPrefs.GetFloat("SliderVolume");
        }
        else slider.value = 0.5f;
    }

    void Update()
    {
        audio.volume = slider.value;
        PlayerPrefs.SetFloat("SliderVolume", slider.value);
        PlayerPrefs.Save();
    }

}
