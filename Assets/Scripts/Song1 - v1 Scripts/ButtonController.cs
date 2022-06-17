using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    /*[SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite pressedImage;*/

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        //_spriteRenderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            //spriteRenderer.sprite = pressedImage;
            _anim.SetTrigger("Pressed");
        }

        /*if (Input.GetKeyUp(keyToPress))
        {
            //spriteRenderer.sprite = defaultImage;
        }*/
    }
}
