using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This Class is responsible for Game Flow of the Song.
/// </summary>


public class SongManagerV2 : MonoBehaviour
{
    [SerializeField] private AudioSource _theMusic;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameEvents _events;
    [SerializeField] private float _offset;

    private float _clipLength;
    private bool _check;

    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        ClipChecker();
    }

    public void GameStarter()
    {
        _clipLength = _theMusic.clip.length;
        StartCoroutine(DelayTime());
    }

    private void ClipChecker()
    {
        if (_check)
            _clipLength -= Time.deltaTime;

        if (_clipLength < 0f)                    //This will check the song if it is finished.
        {
            _check = false;
            _events.Raise();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    #region IEnumerator
    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(_offset);
        GameObject.Destroy(_loadingScreen);
        _theMusic.Play();
        _check = true;
    }
    #endregion
}
