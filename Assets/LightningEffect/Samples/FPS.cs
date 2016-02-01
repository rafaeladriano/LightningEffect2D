using UnityEngine;
using UnityEngine.UI;
using System;

public class FPS : MonoBehaviour {

    public Text FpsLabel;

    private float deltaTime = 0;
    private float fps = 0;

    private float updateTime = 0;

	void Update () {
        deltaTime += Time.deltaTime;
        deltaTime *= 0.5f;
        fps = 1 / deltaTime;

        if (updateTime < 0) {
            FpsLabel.text = "FPS: " + Mathf.Round(fps);
            updateTime = 1;
        }

        updateTime -= Time.deltaTime;

	}
}
