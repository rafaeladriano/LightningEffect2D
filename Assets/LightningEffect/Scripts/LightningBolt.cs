using UnityEngine;
using System.Collections.Generic;

public class LightningBolt : MonoBehaviour {

    public Lightning lightningPrefab;
    public Color LightColor;
    public float MagnetudeRange;
    public int NumberSegments;
    public int NumberLightnings;
    public float Tickeness;
    public float Radius;
    public int NumberSeeds;
    public bool RotationClockwise;
    public float RotationSpeed;
    public bool RandomSize;

    private List<GameObject> seeds;
    private Vector3 rotationClockwiseValue;

    void Start() {

        rotationClockwiseValue = RotationClockwise ? Vector3.forward : Vector3.back;
        seeds = new List<GameObject>(NumberSeeds);

        float radius = Radius* Mathf.Deg2Rad;
        float partius = 360 / NumberSeeds;
        for (int i = 0; i < NumberSeeds; i++) {
            GameObject seed = new GameObject();
            seed.name = "LightningSeed" + i;
            seed.transform.parent = transform;
            seed.transform.position = new Vector3(transform.position.x, transform.position.y + radius, transform.position.z);
            seed.transform.RotateAround(transform.position, Vector3.forward, partius * i);
            seeds.Add(seed);
        }
    }

    void Update() {

        foreach (GameObject seed in seeds) {
            seed.transform.RotateAround(transform.position, rotationClockwiseValue, Time.deltaTime * RotationSpeed);
            for (int i = 0; i < NumberLightnings; i++) {
                CreateLightning(seed);
            }
        }
    }

    private void CreateLightning(GameObject target) {
        Lightning lightning = Instantiate(lightningPrefab);
        lightning.LightColor = LightColor;
        lightning.MagnetudeRange = MagnetudeRange;
        lightning.NumberSegments = NumberSegments;
        lightning.Tickeness = Tickeness;
        lightning.RandomSize = RandomSize;
        lightning.Source = transform;
        lightning.Target = target.transform;
        lightning.transform.parent = transform;
    }

}
