using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName ="Custom/GUI-Info")]
public class GUI_Information : ScriptableObject
{
    [SerializeField] private int _currentScore;
    [SerializeField] private int _combo;
    [SerializeField] private int _currentMultiplier;

    public int GetCurrentScore()
    {
        return _currentScore;
    }

    public int GetCombo()
    {
        return _combo;
    }
    public int GetCurrentMultiplier()
    {
        return _currentMultiplier;
    }

    public void StoreCurrentScore(int value)
    {
        _currentScore = value;
    }

    public void StoreCurrentMultiplier(int value)
    {
        _currentMultiplier = value;
    }

    public void StoreCurrentCombo(int value)
    {
        _combo = value;
    }
}
