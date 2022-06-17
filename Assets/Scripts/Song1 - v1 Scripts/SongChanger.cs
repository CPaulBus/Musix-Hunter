using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongChanger : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _songList;
    private bool _startAudio = false;

    private void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayAudioOnStart()
    {
        _audioSource.clip = _songList[0];
        _audioSource.Play();
        _startAudio = true;
    }

    public void SetAudio(int track)
    {
        if (_audioSource.clip != _songList[0])
        {
            _audioSource.Stop();
            _audioSource.clip = _songList[0];
            _audioSource.Play();
        }
    }

    public void SetAudio(TrackSelectVar trackSelect)
    {
        _audioSource.Stop();
        _audioSource.clip = _songList[trackSelect.trackNumber];
        _audioSource.Play();
    }

    public void AudioStop()
    {
        if (_audioSource.clip != _songList[0])
            _audioSource.Stop();
    }
}
