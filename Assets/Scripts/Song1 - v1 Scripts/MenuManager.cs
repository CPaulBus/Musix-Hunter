using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MenuManager : MonoBehaviour, IMenuManager<int>
{
    private int trackSelect;
    [SerializeField] private IMenuAnimator<string> _menuAnim;
    [SerializeField] private TimelineAsset[] _timeline;
    [SerializeField] private ITimelineManager _timelineManager;

    int IMenuManager<int>.trackSelect
    {
        get { return trackSelect; }
        set { trackSelect = value; }
    }

    private void Start()
    {
        _timelineManager = GetComponent<TimelineManager>();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            _menuAnim = GameObject.Find("MainMenu").GetComponent<MenuAnimator>();
    }

    public void PlayGame()
    {
        _menuAnim.AnimTriggerSet("Next");
    }

    public void Back()
    {
        SetTrackSelect(0);
        _menuAnim.AnimTriggerSet("Back");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetTrackSelect(int requestTrack)
    {
        trackSelect = requestTrack;
    }

    public void playWithChosenSong()    //Towards to Gameplay Scene
    {
        switch (trackSelect)
        {
            case 1:
                Initialization();
                StartCoroutine(ChangeScene());
                break;
            default:
                SetTrackSelect(0);
                break;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("TrackNumber"));
    }

    public void exitSongScene()
    {
        SceneManager.LoadScene(0);
    }

    private void Initialization() //Scene Initialization
    {
        PlayerPrefs.SetInt("TrackNumber", trackSelect);
        _timelineManager.TimelinePlay(_timeline[1]);
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(trackSelect);
    }
}