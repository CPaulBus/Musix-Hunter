using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/Game Event"), System.Serializable]
public class GameEvents : ScriptableObject
{
    private readonly List<IGameEventListener> m_listeners = new List<IGameEventListener>();

    public virtual void Raise()
    {
        for (int i = m_listeners.Count - 1; i >= 0; i--)
            m_listeners[i].OnEventRaised();
    }

    public virtual void RegisterListener(IGameEventListener listener)
    {
        if (!m_listeners.Contains(listener))
            m_listeners.Add(listener);
    }

    public virtual void UnregisterListener(IGameEventListener listener)
    {
        if (m_listeners.Contains(listener))
            m_listeners.Remove(listener);
    }
}
