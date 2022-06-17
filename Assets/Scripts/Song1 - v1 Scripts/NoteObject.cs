using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public IEnemyAnimationController enemyAnim;

    public ICameraShake camShake;

    public IEnemyFX enemyFX;

    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimationController>();
        camShake = GameObject.FindGameObjectWithTag("CamerShake").GetComponent<CameraShake>();
        enemyFX = GetComponent<EnemyFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                enemyAnim.EnemyHit();
                camShake.CamShake();
                enemyFX.EnemyBoom();
                StartCoroutine(DeleteNote(0.2f));
                SongManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            SongManager.instance.MissNote();
            StartCoroutine(DeleteNote(0.3f));
        }
    }

    IEnumerator DeleteNote(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(this.gameObject);
    }
}