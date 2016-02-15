using UnityEngine;
using System.Collections.Generic;

public class Lightning : MonoBehaviour {

    public Color LightColor;
    public float MagnetudeRange;
    public int NumberSegments;
    public float Tickeness;
    public Transform Source;
    public Transform Target;
    public bool RandomSize;

    private List<LineLightning> lines;

    private bool create;

    void Awake() {
        lines = new List<LineLightning>(NumberSegments);
    }

    public void Show() {
        create = true;
    }

    void Update() {

        if (create) {
            CreateLightning();
            create = false;
        }

        if (lines.Count == 0) {
            gameObject.SetActive(false);
        }

    }

    private void CreateLightning() {
        
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

            LineLightning lineLightning = LineLightningPooler.Singleton.GetPooledObject();
            if (lineLightning != null) {
                lineLightning.transform.parent = transform;
                lineLightning.SetColor(LightColor);
                lineLightning.DrawLine(startPoint, endPoint, Tickeness);
                lineLightning.Callback = RemoveLine;
                lineLightning.gameObject.SetActive(true);

                lines.Add(lineLightning);
            }

            startPoint = endPoint;
        }

        transform.RotateAround(sourcePosition, Vector3.forward, angle);
    }

    private void RemoveLine(LineLightning line) {
        lines.Remove(line);
    }

    private float GetAngle(Vector3 origin, Vector3 target) {
        return Mathf.Atan2(target.y - origin.y, target.x - origin.x) * Mathf.Rad2Deg;
    }
}
