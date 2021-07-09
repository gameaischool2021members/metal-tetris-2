using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DeliverySystem))]
public class DeliverySystemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DeliverySystem grid = (DeliverySystem)target;
        if (GUILayout.Button("Reset Grid"))
            grid.Deliver();
    }
}

