using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ObjectPool")]
public class ObjectPool : ScriptableObject
{
    private List<GameObject> _pooledObjects;
    [SerializeField]  private GameObject _objectToPool;
    [SerializeField]  private int _amountToPool;

    public void SpawnPool()
    {
        _pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.SetActive(false);
            _pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i < _amountToPool; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
