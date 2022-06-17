using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SongInformation : MonoBehaviour
{
    [SerializeField] private SongInformationSO _song;
    [SerializeField] private TrackSelectVar trackSelect;
    [SerializeField] private Image _extImage;
    [SerializeField] private TMP_Text[] _songDesc;
    [SerializeField] private GameEvents[] _signal;

    private void Start()
    {

        _extImage = GameObject.FindGameObjectWithTag("AlbumPic").GetComponent<Image>();

        _songDesc[0].GetComponent<TMP_Text>().text = _song.GetSongTitle();
        _songDesc[1].GetComponent<TMP_Text>().text = _song.GetSongBPM() + " BPM";
    }

    public void SetExtDisplay()   //Setting Main Diplay (from the right)
    {
        _extImage.sprite = _song.GetSongImage();
        SetTrackSelect();
        _signal[0].Raise();
    }

    public void SetTrackSelect()
    {
        trackSelect.trackNumber = _song.GetTrackNumber();
    }
}
