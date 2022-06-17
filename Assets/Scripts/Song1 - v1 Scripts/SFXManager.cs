using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _playSFX;

    public void PlaySFX()
    {
        this.GetComponent<AudioSource>().clip = _playSFX[1];
        this.GetComponent<AudioSource>().Play();
    }

    public void ClickSFX()
    {
        this.GetComponent<AudioSource>().clip = _playSFX[0];
        this.GetComponent<AudioSource>().Play();
    }
}
