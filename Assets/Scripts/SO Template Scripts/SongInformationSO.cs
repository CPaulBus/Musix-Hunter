using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="New Song", menuName = "Song/Create Song")]
public class SongInformationSO : ScriptableObject
{
    [Header("Song Description")]
    [SerializeField] private string _songTitle;
    [SerializeField] private int _songBPM;
    [SerializeField] private Sprite _songImage;

    [Header("Util")]
    [SerializeField] private int _trackNumber; //Song Number that will use to decide which scene will be loaded.

    public Sprite extImage;

    public string GetSongTitle()
    {
        return _songTitle;
    }

    public int GetSongBPM()
    {
        return _songBPM;
    }

    public Sprite GetSongImage()
    {
        return _songImage;
    }

    public int GetTrackNumber()
    {
        return _trackNumber;
    }
}
