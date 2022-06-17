using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplierHandlerV2 : MonoBehaviour, IMultiplierHandler
{
    [SerializeField] private int _currentMultiplier;
    [SerializeField] private int _multiplierTracker;
    [SerializeField] private int[] _multiplierTresholds;
    [SerializeField] private GUI_Information _gUI;

    private void Start()
    {
        SetMultiplier(1);
        _gUI.StoreCurrentMultiplier(1);
    }

    public void SetMultiplier(int multi)
    {
        _currentMultiplier = multi;
    }

    public void SaveMultiplier()
    {
        _gUI.StoreCurrentMultiplier(_currentMultiplier);
    }

    public int GetMultiplier()
    {
        return _currentMultiplier;
    }

    public void MultiplierChecker()
    {
        if (_currentMultiplier - 1 < _multiplierTresholds.Length)
        {
            _multiplierTracker++;

            if (_multiplierTresholds[_currentMultiplier - 1] <= _multiplierTracker)
            {
                _multiplierTracker = 0;
                _currentMultiplier++;
            }
        }
    }
}
