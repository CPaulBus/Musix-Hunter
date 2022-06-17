using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    [SerializeField] private string _TagName;
    [SerializeField] private ObjectPool _notes;

    private void Start()
    {
        _notes.SpawnPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_TagName))
        {
            GameObject note = _notes.GetPooledObject();
            if (note != null)
            {
                note.transform.SetParent(other.transform);
                note.transform.position = other.transform.position;
                note.SetActive(true);
            }            
        }
    }
}
