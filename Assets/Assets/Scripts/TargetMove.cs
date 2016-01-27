using UnityEngine;
using System.Collections;

public class TargetMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetMouseButton(0)) {
            Vector3 v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(v);
            pos.z = 0;
            transform.position = pos;
        }

	}
}
