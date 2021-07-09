using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] AccountBalance _accountBalance;
    GridSystem _grid;
    GridPrefabDestroyer _destroyer;
    RedLineManager _redLineManager;

    public GridSystem Grid {set => _grid = value; }

    private void Awake()
    {
        _destroyer = GetComponent<GridPrefabDestroyer>();
        _redLineManager = GetComponent<RedLineManager>();
    }

    public void Deliver()
    {
        _grid.ClearCells();
        _destroyer.DestroyPiecesInGrid();
        _accountBalance.AddToBalance(-_redLineManager.ActualCost);
    }


}
