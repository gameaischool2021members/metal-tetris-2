using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    GridSystem _grid;
    GridPrefabDestroyer _destroyer;

    public GridSystem Grid {set => _grid = value; }

    private void Awake() => _destroyer = GetComponent<GridPrefabDestroyer>();
    public void ClearGrid()
    {
        _grid.ClearCells();
        _destroyer.DestroyPiecesInGrid();
    }


}
