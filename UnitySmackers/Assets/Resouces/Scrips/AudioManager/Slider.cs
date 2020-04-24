using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public AudioMixer mixer;

    public void SliderValue(float value)
    {
        mixer.SetFloat("main_mixer", value);
    }
}
