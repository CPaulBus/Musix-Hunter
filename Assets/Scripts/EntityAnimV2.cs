using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimV2 : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private bool _letStart;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_letStart)
            _anim.SetTrigger("LetStart");
    }

    public void SetBoolLetStart(bool value)
    {
        _letStart = value;
    }
}
