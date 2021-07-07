using UnityEngine;
using static Direction;

public class GridSystem
{
    readonly int _width;
    readonly int _height;
    readonly float _cellSize;

    readonly int[,] _gridArray;
    readonly TextMesh[,] _debugTextArray;

    public GridSystem(int width, int height,float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;

        _gridArray = new int[width, height];
        _debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                string text = _gridArray[x, y].ToString();
                Vector3 textPosition = GetWorldPosition(x, y)+new Vector3(_cellSize, _cellSize) * 0.5f;
                _debugTextArray[x,y] = DebugWorldText.CreateWorldText(text,textPosition);

                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x+1,y), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y+1), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width, _height), Color.white, 100f);
    }

    public Vector3 GetWorldPosition(int x, int y) => new Vector3(x, y) * _cellSize;

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }

    public void SetValue(int x, int y, int value) 
    {
        if (!IsInsideGrid(x, y)) return;

        _gridArray[x, y] = value;
        _debugTextArray[x, y].text = _gridArray[x, y].ToString();
    }
    public void SetValue(Vector3 worldPosition, int value)
    {
        GetXY(worldPosition, out int x, out int y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) => IsInsideGrid(x, y)? _gridArray[x, y]: default;
    public int GetValue(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetValue(x, y);
    }

    public void OccupyCells(Vector2Int mousePosition, Piece piece)
    {
        foreach (Vector2Int pieceCell in piece.PieceSO.CoveredCells)
        {
            Vector2Int cell = RotationCellHandler(pieceCell, piece.PieceSO.PivotPoint, piece.Facing);
            int x = cell.x + mousePosition.x;
            int y = cell.y + mousePosition.y;
            SetValue(x, y, 1);
        }
    }

    public bool ValidPositionCheck(Vector2Int mousePosition , Piece piece)
    {
        foreach (Vector2Int pieceCell in piece.PieceSO.CoveredCells)
        {
            Vector2Int cell = RotationCellHandler(pieceCell, piece.PieceSO.PivotPoint, piece.Facing);
            int x = cell.x + mousePosition.x;
            int y = cell.y + mousePosition.y;

            if (!IsInsideGrid(x, y)) return false;
            if (GetValue(x, y) == 1) return false;
        }
        return true;
    }

    Vector2Int RotationCellHandler(Vector2Int cell,Vector2Int pivotPoint, Facing direction)
    {
        int x = cell.x, y = cell.y;
        switch (direction)
        {
            case Facing.Right:
                cell -= pivotPoint;
                cell.x = y;
                cell.y = -x;
                cell += pivotPoint;
                break;
            case Facing.Down:
                cell -= pivotPoint;
                cell.x = -x;
                cell.y = -y;
                cell += pivotPoint;
                break;
            case Facing.Left:
                cell -= pivotPoint;
                cell.x = -y;
                cell.y = x;
                cell += pivotPoint;
                break;
            default:
                break;
        }
        return cell;
    }

    bool IsInsideGrid(int x, int y) => (x >= 0 && y >= 0 && x < _width && y < _height) ? true : false;
}
