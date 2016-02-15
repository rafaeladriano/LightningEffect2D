using UnityEngine;

public class LightningEffect : MonoBehaviour {

    public Color LightColor;
    public float MagnetudeRange;
    public int NumberSegments;
    public int NumberLightnings;
    public float Tickeness;
    public Transform Source;
    public Transform Target;
    public float CreateLightningDelay;

    private float delay;

    void Update() {
        delay -= Time.deltaTime;
        if (delay < 0) {
            for (int i = 0; i < NumberLightnings; i++) {
                CreateLightning();
            }
            delay = CreateLightningDelay;
        }
	}

    private void CreateLightning() {
        Lightning lightning = LightningPooler.Singleton.GetPooledObject();
        if (lightning != null) {
            lightning.transform.parent = transform;
            lightning.Source = Source;
            lightning.Target = Target;
            lightning.LightColor = LightColor;
            lightning.MagnetudeRange = MagnetudeRange;
            lightning.NumberSegments = NumberSegments;
            lightning.Tickeness = Tickeness;
            lightning.Show();
            lightning.gameObject.SetActive(true);
        }
    }
	
	
}
