using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolerSystem<T> where T:Component {

    public List<T> pooledObjects;

    private int pooledAmount;
    private T pooledPrefab;
    private bool willGrow;

    public ObjectPoolerSystem(T pooledPrefab, int pooledAmount, bool willGrow) {

        this.pooledPrefab = pooledPrefab;
        this.willGrow = willGrow;
        this.pooledObjects = new List<T>();

        for (int i = 0; i < pooledAmount; i++) {
            T obj = Object.Instantiate(pooledPrefab);
            obj.name = pooledPrefab.name + " " + i;
            obj.gameObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    
    public T GetPooledObject() {
        if (pooledObjects == null) {
            return null;
        }

        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].gameObject.activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        
        if (willGrow) {
            T obj = Object.Instantiate(pooledPrefab);
            obj.name = pooledPrefab.name + " " + pooledObjects.Count;
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

}
