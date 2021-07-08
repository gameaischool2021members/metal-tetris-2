using UnityEngine;

public class GridPrefabDestroyer : MonoBehaviour
{
    [SerializeField] Transform _piecesInGridParent;

    public void DestroyPiecesInGrid()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
