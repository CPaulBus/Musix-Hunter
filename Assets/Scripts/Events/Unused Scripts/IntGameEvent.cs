using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New IntGameEvent", menuName = "Event/IntGameEvent"),System.Serializable]
public class IntGameEvent:ScriptableObject
{
    private readonly List<IGameEventListener<int>> m_listeners = new List<IGameEventListener<int>>();

    public virtual void Raise(int value)
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
            m_listeners[i].IntOnEventRaised(value);
    }

    public virtual void RegisterListener(IGameEventListener<int> listener)
    {
        if (!m_listeners.Contains(listener))
            m_listeners.Add(listener);
    }

    public virtual void UnregisterListener(IGameEventListener<int> listener)
    {
        if (m_listeners.Contains(listener))
            m_listeners.Remove(listener);
    }
}