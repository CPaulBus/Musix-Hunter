using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using TMPro;

public class PauseV2 : MonoBehaviour
{
    private static bool _isPaused;

    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _timerObject;
    [SerializeField] private TMP_Text _timerPause;
    [SerializeField] private GameEvents[] _pauseEvent;

    private void Start()
    {
        _pause.SetActive(false);
    }

    private void Awake()
    {
        _isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }

    }

    public void PauseButton()
    {
        _isPaused = !_isPaused;
        PauseGame();
    }

    private void PauseGame()
    {
        if (_isPaused)
        {
            _pause.SetActive(true);
            _pauseEvent[0].Raise();
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else
            ResumeGame();

    }

    private void ResumeGame()
    {
        _pause.SetActive(false);
        _timerObject.SetActive(true);
        StartCoroutine(DelayResume());
    }

    public void Retry()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(PlayerPrefs.GetInt("TrackNumber"));
    }

    public void ReturnMainMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    IEnumerator DelayResume()
    {
        _timerPause.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        _timerPause.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        _timerPause.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        _pauseEvent[1].Raise();
        AudioListener.pause = false;
        _timerObject.SetActive(false);
        Time.timeScale = 1;
    }
}
