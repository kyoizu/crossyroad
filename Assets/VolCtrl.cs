using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolCtrl : MonoBehaviour
{
    [SerializeField] private Slider volSlider = null;
    [SerializeField] private Text volText = null;

    private void Start() 
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volText.text = volume.ToString("0.0");
    }

    public void SaveVolume()
    {
        float volValue = volSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volValue);
        LoadValues();
    }

    private void LoadValues()
    {
        float volValue = PlayerPrefs.GetFloat("VolumeValue");
        volSlider.value = volValue;
        AudioListener.volume = volValue;
    }
}
