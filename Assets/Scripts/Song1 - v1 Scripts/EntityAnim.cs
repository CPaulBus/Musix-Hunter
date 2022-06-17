using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnim : MonoBehaviour
{
    private Animator anim;
    ISongManagerSub<bool> songManager;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        songManager = GameObject.Find("GameManager").GetComponent<SongManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (songManager.letStart)
        {
            anim.SetTrigger("LetStart");
        }
    }
}
