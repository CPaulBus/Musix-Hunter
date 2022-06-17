using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObjectV2 : MonoBehaviour
{
    private bool _canBePressed = false;

    [SerializeField] private KeyCode _keyToPress;

    [SerializeField] private IEnemyAnimationController _enemyAnim;

    [SerializeField] private IEnemyFX _enemyFX;

    [SerializeField] private GameEvents[] _events;

    private void Awake()
    {
        _enemyAnim = GetComponent<EnemyAnimationController>();
        _enemyFX = GetComponent<EnemyFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_keyToPress))
        {
            if (_canBePressed)
            {
                _enemyAnim.EnemyHit();
                _events[2].Raise();
                _enemyFX.EnemyBoom();
                StartCoroutine(DeleteNote(0.2f));
                _events[0].Raise();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Activator"))
        {
            _canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Activator"))
        {
            _canBePressed = false;
            _events[1].Raise();
            StartCoroutine(DeleteNote(0.3f));
        }
    }

    IEnumerator DeleteNote(float time)
    {
        yield return new WaitForSeconds(time);
        _canBePressed = false;
        gameObject.SetActive(false);
    }
}
