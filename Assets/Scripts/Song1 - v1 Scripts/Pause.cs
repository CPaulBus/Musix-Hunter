using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using TMPro;

public class Pause : MonoBehaviour
{
    private static bool isPaused;

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject timerObject;
    [SerializeField] private TMP_Text timerPause;

    #region Interfaces
    private ISongTimelineManager<TimelineAsset> smg;
    private ISongManagerSub<bool> songManager;
    #endregion

    private void Start()
    {
        pause.SetActive(false);
        smg = GameObject.Find("TimelineManager").GetComponent<SongTimelineManager>();
        songManager = GetComponent<SongManager>();
    }

    private void Awake()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && songManager.letStart)
        {
            PauseButton();
        }

    }

    public void PauseButton()
    {
        isPaused = !isPaused;
        PauseGame();
    }

    private void PauseGame()
    {
        if (isPaused)
        {
            pause.SetActive(true);
            NoteScroller.instance.hasStarted = false;
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else
            ResumeGame();
              
    }

    private void ResumeGame()
    {
        pause.SetActive(false);
        timerObject.SetActive(true);
        StartCoroutine(DelayResume());        
    }

    public void Retry()
    {
        Time.timeScale = 1;
        smg.SetisClicked();
        AudioListener.pause = false;
        SceneManager.LoadScene("Song1");
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    IEnumerator DelayResume()
    {
        timerPause.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        timerPause.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        timerPause.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        NoteScroller.instance.hasStarted = true;
        AudioListener.pause = false;
        timerObject.SetActive(false);
        Time.timeScale = 1;
    }
}
