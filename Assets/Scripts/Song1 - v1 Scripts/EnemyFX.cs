using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFX : MonoBehaviour, IEnemyFX
{
    public ParticleSystem particle;
    public void EnemyBoom()
    {
        particle.Play();
    }
}
