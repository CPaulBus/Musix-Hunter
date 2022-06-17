using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This Class is responsible for Main Menu Logic
/// </summary>

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private int _trackSelect;
    [SerializeField] private IMenuAnimator<string> _menuAnim;
    [SerializeField] private GameEvents _transition;
    [SerializeField] private GameEvents _ChangeAudio;
    [SerializeField] private TrackSelectVar _selectVar;

    private void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            _menuAnim = GameObject.Find("MainMenu").GetComponent<MenuAnimator>();
    }

    public void Back()
    {
        _menuAnim.AnimTriggerSet("Back");
    }

    public void PlayGame()
    {
        _menuAnim.AnimTriggerSet("Next");
    }

    public void playWithChosenSong()
    {
        switch (_trackSelect)
        {
            case 1:
                Initialization();
                StartCoroutine(ChangeScene());
                break;
            default:
                _selectVar.trackNumber = 0;
                _ChangeAudio.Raise();
                break;
        }
    }

    private void Initialization()
    {
        PlayerPrefs.SetInt("TrackNumber", _trackSelect);
        _transition.Raise();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetTrackSelect(int requestTrack)
    {
        _trackSelect=requestTrack;
        _selectVar.trackNumber = requestTrack;
    }

    public void SetTrackSelect(TrackSelectVar requestTrack)
    {
        _trackSelect = requestTrack.trackNumber;
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(_trackSelect);
    }
}
