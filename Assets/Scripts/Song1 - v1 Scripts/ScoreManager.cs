using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ScoreManager : MonoBehaviour, IScoreManager
{
    public TMP_Text[] playerScore;  //SerializeField

    [SerializeField] private int currentScore;
    [SerializeField] private int notesHit;
    [SerializeField] private int maxCombo;

    #region Variables for Gameplay Scene
    [SerializeField] private int scorePerNote = 100;
    [SerializeField] private int combo;
    [SerializeField] private IMultiplierHandler multiplier;     //New Class to
    #endregion

    void Start()
    {
        PlayerPrefsKeyChecker();    // Check if Key exists

        if (SceneManager.GetSceneByName("Song1") == SceneManager.GetActiveScene())
        {
            multiplier = GetComponent<MultiplierHandler>();

            playerScore[0].text = "Score: " + 0;
            multiplier.SetMultiplier(1);
            maxCombo = notesHit = currentScore = combo = 0;
        }

        multiplier = GetComponent<MultiplierHandler>();
    }

    private void Update()
    {
        ValueToUIText();    // Value to Text UI Update
    }

    #region Public Functions
    public void SaveScore()
    {
        PlayerPrefs.SetInt("NotesHit", notesHit);
        PlayerPrefs.SetInt("MaxCombo", maxCombo);
        PlayerPrefs.SetInt("Score", currentScore);
    }

    public void SetNoteHit(int hit)
    {
        notesHit += hit;
    }

    public void AddCombo(int v)
    {
        combo += v;
    }

    public void SetCombo(int v)
    {
        combo = v;
    }

    public void ComboChecker()
    {
        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
    }

    public void ComboGameObjectActivator(bool activate)
    {
        playerScore[1].gameObject.SetActive(activate);
    }

    public void SetCurrScore()  //Set Current Score and Combo to UI
    {
        currentScore += scorePerNote * multiplier.GetMultiplier();
        playerScore[0].text = "Score: " + currentScore;
        playerScore[1].text = combo.ToString();
    }
    #endregion

    #region Private Functions
    private void ValueToUIText()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            playerScore[0].text = currentScore.ToString();
            playerScore[1].text = notesHit.ToString();
            playerScore[2].text = maxCombo.ToString();
        }
        else
        {
            playerScore[0].text = "Score: " + currentScore;
        }

    }

    private void PlayerPrefsKeyChecker()
    {
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("NotesHit") && PlayerPrefs.HasKey("MaxCombo"))
        {
            currentScore = PlayerPrefs.GetInt("Score");
            notesHit = PlayerPrefs.GetInt("NotesHit");
            maxCombo = PlayerPrefs.GetInt("MaxCombo");
        }
        else
        {
            currentScore = 0;
            notesHit = 0;
            maxCombo = 0;
        }
    }
    #endregion
}