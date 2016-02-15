using UnityEngine;
using System.Collections.Generic;

public class LightningPooler : MonoBehaviour {

    public static LightningPooler Singleton;

    public Lightning PooledPrefab;
    public int PooledAmount;
    public bool WillGrow;
    public List<Lightning> pooledObjects;

    private ObjectPoolerSystem<Lightning> objectPooler;

	void Awake () {
        Singleton = this;
        if (objectPooler == null) {
            objectPooler = new ObjectPoolerSystem<Lightning>(PooledPrefab, PooledAmount, WillGrow);
            pooledObjects = objectPooler.pooledObjects;
        }
    }

    public Lightning GetPooledObject() {
        return objectPooler.GetPooledObject();
    }

}
