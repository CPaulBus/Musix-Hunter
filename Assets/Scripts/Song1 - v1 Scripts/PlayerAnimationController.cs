using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _anim.SetTrigger("Attack1");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _anim.SetTrigger("Attack2");
        }
    }
}
