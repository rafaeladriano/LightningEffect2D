using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {

    private bool moving = false;

	void Start () {
	
	}
	
	void Update () {
	
        if (Input.GetMouseButton(0)) {
            if (GetComponent<BoxCollider2D>().bounds.Contains(GetMousePosition())) {
                moving = true;
            }
        } else {
            moving = false;
        }

        if (moving) {
            transform.position = GetMousePosition();
        }
    }

    private Vector3 GetMousePosition() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
