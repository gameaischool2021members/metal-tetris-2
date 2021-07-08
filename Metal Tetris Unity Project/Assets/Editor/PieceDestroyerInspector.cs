using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridPrefabDestroyer))]
public class PieceDestroyerInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GridPrefabDestroyer destroyer = (GridPrefabDestroyer)target;
        if (GUILayout.Button("Destroy Pieces In Grid"))
            destroyer.DestroyPiecesInGrid();
    }
}
