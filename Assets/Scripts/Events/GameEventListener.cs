using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }

public class GameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField] private GameEvents Event;
    [SerializeField] private UnityEvent Response;

    public void OnEnable()
    {
        if (Event != null) Event.RegisterListener(this);
    }

    public void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response?.Invoke();
    }
}