using UnityEngine;

public class GridPrefabDestroyer : MonoBehaviour
{
    [SerializeField] Transform _piecesInGridParent;

    public void DestroyPiecesInGrid()
    {
        foreach (Transform child in _piecesInGridParent)
        {
            Destroy(child.gameObject);
        }
    }
}
