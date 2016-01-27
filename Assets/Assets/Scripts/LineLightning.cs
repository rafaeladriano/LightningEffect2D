using UnityEngine;

public class LineLightning : MonoBehaviour {

    private SpriteRenderer lightSprite;

    void Start () {
        lightSprite = GetComponent<SpriteRenderer>();
	}

    public void SetColor(Color color) {
        lightSprite = GetComponent<SpriteRenderer>();
        lightSprite.color = color;
    }

    public void DrawLine(Vector2 A, Vector2 B, float tickeness) {

        Vector2 difference = B - A;
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //Set the scale of the line to reflect length and thickness
        transform.localScale = new Vector3(100 * (difference.magnitude / GetComponent<SpriteRenderer>().sprite.rect.width), tickeness, transform.localScale.z);

        //Rotate the line so that it is facing the right direction
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));

        //Move the line to be centered on the starting point
        transform.position = new Vector3(A.x, A.y, transform.position.z);

        //Need to convert rotation to radians at this point for Cos/Sin
        rotation *= Mathf.Deg2Rad;

        //Store these so we only have to access once
        float lineChildWorldAdjust = transform.localScale.x * GetComponent<SpriteRenderer>().sprite.rect.width / 2f;

        //Adjust the middle segment to the appropriate position
        transform.position += new Vector3(.01f * Mathf.Cos(rotation) * lineChildWorldAdjust, .01f * Mathf.Sin(rotation) * lineChildWorldAdjust, 0);

    }
	
	void Update () {

        lightSprite.color = new Color(lightSprite.color.r, lightSprite.color.g, lightSprite.color.b, lightSprite.color.a - (10f * Time.deltaTime));

        if (lightSprite.color.a <= 0f) {
            Destroy(gameObject);
        }

    }
}
