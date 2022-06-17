using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScrollerV2 : MonoBehaviour
{
    [SerializeField] private float _beatTempo;
    [SerializeField] private SongInformationSO _song;
    [SerializeField] private bool _hasStarted;

    Vector3 currPos;

    void Start()
    {

        _beatTempo = _song.GetSongBPM();
        _beatTempo = _beatTempo / 60f;
    }

    public void HuntBegins()
    {
        if (_hasStarted)
        {
            StartCoroutine(DelayTime());
        }
    }

    public void SethasStarted(bool value)
    {
        _hasStarted = value;        
    }

    void Update()
    {
        HuntBegins();
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        transform.position -= new Vector3(_beatTempo * Time.deltaTime, 0f, 0f);
    }
}
