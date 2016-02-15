using UnityEngine;
using System.Collections.Generic;

public class LineLightningPooler : MonoBehaviour {

    public static LineLightningPooler Singleton;

    public LineLightning PooledPrefab;
    public int PooledAmount;
    public bool WillGrow;
    public List<LineLightning> pooledObjects;

    private ObjectPoolerSystem<LineLightning> objectPooler;

    void Awake() {
        Singleton = this;
        if (objectPooler == null) {
            objectPooler = new ObjectPoolerSystem<LineLightning>(PooledPrefab, PooledAmount, WillGrow);
            pooledObjects = objectPooler.pooledObjects;
        }
    }

    public LineLightning GetPooledObject() {
        return objectPooler.GetPooledObject();
    }
}
