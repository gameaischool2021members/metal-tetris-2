using UnityEngine;

public class DebugWorldText
{
    public static TextMesh CreateWorldText(string text, Vector3 localPosition)
    {
        GameObject gameObject = new GameObject("WorldText", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.localPosition = localPosition;

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.text = text;
        textMesh.color = Color.red;
        textMesh.fontSize = 8;

        return textMesh;
    }
}
