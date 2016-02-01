using UnityEngine;
using System.Collections.Generic;

public class Lightning : MonoBehaviour {

    public LineLightning LineLightningPrefab;
    public Color LightColor;
    public float MagnetudeRange;
    public int NumberSegments;
    public float Tickeness;
    public Transform Source;
    public Transform Target;
    public bool RandomSize;

    private List<LineLightning> lines;

    void Start() {

        lines = new List<LineLightning>(NumberSegments);

        Vector3 sourcePosition = Source.position;
        Vector3 targetPosition = Target.position;

        float distance = Vector3.Distance(targetPosition, sourcePosition);

        if (RandomSize) {
            float min = distance * 0.25f;
            distance = Random.Range(min, distance);
        }

        float movePartiusLine = distance / NumberSegments;

        float angle = GetAngle(sourcePosition, targetPosition) - 90;

        Vector3 startPoint = sourcePosition;
        for (int i = 1; i <= NumberSegments; i++) {

            float y = (i * movePartiusLine) + sourcePosition.y;
            float x = Random.Range(-MagnetudeRange, MagnetudeRange) + sourcePosition.x;

            Vector3 endPoint = new Vector3(x, y, sourcePosition.z);

            LineLightning lineLightning = Instantiate(LineLightningPrefab);
            lineLightning.transform.SetParent(transform);
            lineLightning.DrawLine(startPoint, endPoint, Tickeness);
            lineLightning.SetColor(LightColor);

            lines.Add(lineLightning);

            startPoint = endPoint;
        }

        transform.RotateAround(sourcePosition, Vector3.forward, angle);
    }

    private float GetAngle(Vector3 origin, Vector3 target) {
        return Mathf.Atan2(target.y - origin.y, target.x - origin.x) * Mathf.Rad2Deg;
    }

    void Update() {

        foreach (LineLightning line in lines) {
            if (line) {
                return;
            }
        }

        Destroy(gameObject);

    }


}
