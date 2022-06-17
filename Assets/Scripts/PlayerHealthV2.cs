using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthV2 : MonoBehaviour
{    
    [SerializeField] private PlayerHealthSO health;
    [SerializeField] private GameEvents events;

    private void Start()
    {
        health.SetHealth(100f);
    }

    private void Update()
    {
        if (health.GetHealth() <= 0)
            events.Raise();
    }

    public void HealthDecrease(float minus)
    {
        health.SetHealth(health.GetHealth() - minus);
    }
}
