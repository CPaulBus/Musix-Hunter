using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManagerV2 : MonoBehaviour
{
    [SerializeField] private int _currentScore;
    [SerializeField] private int _notesHit;
    [SerializeField] private int _maxCombo;

    #region Variables for Gameplay Scene
    [SerializeField] private int _scorePerNote = 100;
    [SerializeField] private int _combo;
    [SerializeField] private IMultiplierHandler _multiplier;
    [SerializeField] private GUI_Information _gUI;
    #endregion

    void Start()
    {
        PlayerPrefsKeyChecker();    // Check if Key exists
        _maxCombo = _notesHit = _currentScore = _combo = 0;
        _gUI.StoreCurrentCombo(0);
        _gUI.StoreCurrentScore(0);
    }

    #region Public Functions
    public void SaveScore()
    {
        PlayerPrefs.SetInt("NotesHit", _notesHit);
        PlayerPrefs.SetInt("MaxCombo", _maxCombo);
        PlayerPrefs.SetInt("Score", _currentScore);
    }

    public void SetNoteHit(int hit)
    {
        _notesHit += hit;
    }

    public void AddCombo(int v)
    {
        _combo += v;
        _gUI.StoreCurrentCombo(_combo);
    }

    public void SetCombo(int v)
    {
        _combo = v;
        _gUI.StoreCurrentCombo(_combo);
    }

    public void ComboChecker()
    {
        if (_combo > _maxCombo)
        {
            _maxCombo = _combo;
        }
    }

    public void SetCurrScore()  //Set Current Score with multiplier
    {
        _currentScore += _scorePerNote * _gUI.GetCurrentMultiplier();
        _gUI.StoreCurrentScore(_currentScore);
    }
    #endregion

    #region Private Functions
    private void PlayerPrefsKeyChecker()
    {
        if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("NotesHit") && PlayerPrefs.HasKey("MaxCombo"))
        {
            _currentScore = PlayerPrefs.GetInt("Score");
            _notesHit = PlayerPrefs.GetInt("NotesHit");
            _maxCombo = PlayerPrefs.GetInt("MaxCombo");
        }
        else
        {
            _currentScore = 0;
            _notesHit = 0;
            _maxCombo = 0;
        }
    }
    #endregion
}
