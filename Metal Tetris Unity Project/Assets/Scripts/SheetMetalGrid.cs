using UnityEngine;

public class SheetMetalGrid : MonoBehaviour
{
    [SerializeField] int _cellDensityFactor = 1;
    int _defaultWidth = 6, _defaultHeigth = 10;
    float _defaultCellSize = 1f;

    GridSystem _grid;

    void Awake() => _grid = new GridSystem(_defaultWidth * _cellDensityFactor,
                                                _defaultHeigth*_cellDensityFactor,
                                                _defaultCellSize / _cellDensityFactor);

    private void Start()
    {
        PieceSelection pieceSelection = GetComponent<PieceSelection>();
        pieceSelection.Grid = _grid;
        RedLineManager redLine = GetComponent<RedLineManager>();
        redLine.SetGrid(_grid);
    }
}
