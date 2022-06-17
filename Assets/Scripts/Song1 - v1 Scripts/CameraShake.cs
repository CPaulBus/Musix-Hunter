using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour, ICameraShake
{
    [SerializeField] private Animator _anim;

    public void CamShake()
    {
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                _anim.SetTrigger("ShakeUp");
                break;
            case 1:
                _anim.SetTrigger("ShakeDown");
                break;
            case 2:
                _anim.SetTrigger("ShakeLeft");
                break;
            case 3:
                _anim.SetTrigger("ShakeRight");
                break;
        }
    }
}
