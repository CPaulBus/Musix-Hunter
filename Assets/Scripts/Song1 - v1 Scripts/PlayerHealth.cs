using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    public static PlayerHealth instance;
    public bool isDead;

    private void Start()
    {
        instance = this;
        Health = 100f;
    }

    private void Update()
    {
        Checker();
    }

    public void HealthDecrease(float minus)
    {
        Health -= minus;
    }

    void Checker()
    {
        if (Health <= 0)
            isDead = true;
    }

    public float GetHealth()
    {
        return Health;
    }
}
