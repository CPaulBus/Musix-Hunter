using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour, INoteScroller<bool>
{
    [SerializeField] private float _beatTempo;

    public bool hasStarted;
    Vector3 currPos;

    public static NoteScroller instance;

    bool INoteScroller<bool>.hasStarted
    {
        get
        {
            return hasStarted;
        }
        set { hasStarted = value; }
    }

    void Start()
    {
        instance = this;

        _beatTempo = _beatTempo / 60f;
    }

    public void HuntBegins()
    {
        if (hasStarted)
        {
            StartCoroutine(DelayTime());
        }
    }

    void Update()
    {
        HuntBegins();
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        transform.position -= new Vector3(_beatTempo * Time.deltaTime, 0f, 0f);
    }
}
