using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;

    public GameObject saveVolumeText;

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 1.0f);
        }
        LoadValues();
    }

    private void Update()
    {
        SaveVolume();
    }

    public void SaveVolume()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
        StartCoroutine(PopUpText());
    }

    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");

        if (volumeSlider == null)
        {
            volumeSlider.value = 0;
        }
        else
        {
            volumeSlider.value = volumeValue;
        }
        
        AudioListener.volume = volumeValue;
    }

    IEnumerator PopUpText()
    {
        saveVolumeText.SetActive(true);
        yield return new WaitForSeconds(2f);
        saveVolumeText.SetActive(false);
    }
}
