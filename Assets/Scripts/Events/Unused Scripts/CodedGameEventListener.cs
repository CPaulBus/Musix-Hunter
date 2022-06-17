using System;
using UnityEngine;

public class CodedGameEventListener : IGameEventListener
{
    [SerializeField] private GameEvents _event;

    private Action m_onResponse;

    public void OnEventRaised()
    {
        m_onResponse?.Invoke();
    }

    public void OnEnable(Action response)
    {
        if (_event != null) _event.RegisterListener(this);
        m_onResponse = response;
    }

    public void OnDisable()
    {
        if (_event != null) _event.UnregisterListener(this);
        m_onResponse = null;
    }
}
