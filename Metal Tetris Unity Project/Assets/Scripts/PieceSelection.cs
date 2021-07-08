using UnityEngine;
using static Direction;

public class PieceSelection : MonoBehaviour
{
    [SerializeField] Transform _piecesParent;
    Piece _actualPiece;
    Transform _pieceObject;
    GridSystem _grid;
    PlayerController _controller;
    Vector2 _positionCorrection = new Vector2(-0.5f, -0.5f);
    public GridSystem Grid {set => _grid = value;}

    private void OnEnable()
    {
        _controller.PlayerClicked += PlacePieceInGrid;
        _controller.PlayerRotate += RotatePiece;
    }
    private void OnDisable()
    {
        _controller.PlayerClicked -= PlacePieceInGrid;
        _controller.PlayerRotate -= RotatePiece;
    }

    void Awake() => _controller = GetComponent<PlayerController>();

    void Update() => _pieceObject.position = _controller.MousePosition + _positionCorrection;

    public void SetActualPiece(Piece piece)
    {
        if (_pieceObject !=null) Destroy(_pieceObject);
        _actualPiece = piece;
        _pieceObject = Instantiate(_actualPiece.PieceSO.PrefabTransform, Vector3.zero, Quaternion.identity);
    }

    private void PlacePieceInGrid(Vector3 mouseWorldPosition)
    {
        _grid.GetXY(mouseWorldPosition, out int x, out int y);
        Vector2Int mousePosition = new Vector2Int(x, y);
        if (!_grid.ValidPositionCheck(mousePosition, _actualPiece)) return;
        _grid.OccupyCells(mousePosition, _actualPiece);

        Vector3 correction = new Vector3(0.5f + _positionCorrection.x, 0.5f + _positionCorrection.y, 0);
        Instantiate(_actualPiece.PieceSO.PrefabTransform, _grid.GetWorldPosition(x, y)+correction, _pieceObject.localRotation,_piecesParent);
    }

    void RotatePiece(float side) 
    {
        Facing facing = _actualPiece.Facing;
        if (side>0) facing = RotateRight(facing);
        else facing = RotateLeft(facing);
        _actualPiece.Facing = facing;

        _pieceObject.Rotate(Vector3.forward, -90f*side);
        SetCorrection();
    }

    void SetCorrection()
    {
        float angle = _pieceObject.localEulerAngles.z;
        if (angle == 0) _positionCorrection = new Vector2(-0.5f, -0.5f);
        if (angle == 90) _positionCorrection = new Vector2(0.5f, -0.5f);
        if (angle == 180) _positionCorrection = new Vector2(0.5f, 0.5f);
        if (angle == 270) _positionCorrection = new Vector2(-0.5f, 0.5f);
    }
}
