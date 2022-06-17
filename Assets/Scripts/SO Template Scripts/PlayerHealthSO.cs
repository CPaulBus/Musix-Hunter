using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerHealth")]
public class PlayerHealthSO : ScriptableObject
{
    [SerializeField] private float _Health;

    public void SetHealth(float value)
    {
        _Health = value;
    }

    public float GetHealth()
    {
        return _Health;
    }
}
