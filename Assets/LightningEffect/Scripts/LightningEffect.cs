using UnityEngine;
using System.Collections;

public class LightningEffect : MonoBehaviour {

    public Lightning lightningPrefab;
    public Color LightColor;
    public float MagnetudeRange;
    public int NumberSegments;
    public int NumberLightnings;
    public float Tickeness;
    public Transform Source;
    public Transform Target;

    void Update() {
        for (int i = 0; i < NumberLightnings; i++) {
            CreateLightning();
        }
	}

    private void CreateLightning() {
        Lightning lightning = Instantiate(lightningPrefab);
        lightning.LightColor = LightColor;
        lightning.MagnetudeRange = MagnetudeRange;
        lightning.NumberSegments = NumberSegments;
        lightning.Tickeness = Tickeness;
        lightning.Source = Source;
        lightning.Target = Target;
    }
	
	
}
