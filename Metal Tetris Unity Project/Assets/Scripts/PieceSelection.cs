using System;
using System.Collections.Generic;
using UnityEngine;
using static Direction;
using static PieceTypeEnum;

public class PieceSelection : MonoBehaviour
{
    [SerializeField] Transform _piecesParent;
    [SerializeField] AgentModeToggle _agentMode;
    [SerializeField] OrderManager _orderManager;
    PieceManager _pieceManager;
    List<Piece> _pieceList;
    Piece _actualPiece;
    Transform _pieceObject;
    GridSystem _grid;
    PlayerController _controller;



    Vector2Int _agentPosition;

    Vector2 _positionCorrection = new Vector2(-0.5f, -0.5f);
    public List<Piece> PieceList {set => _pieceList = value; }
    public GridSystem Grid {set => _grid = value;}
    public Piece ActualPiece => _actualPiece;
    public Vector2Int AgentPosition => _agentPosition;


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

    void Awake()
    {
        _controller = GetComponent<PlayerController>();
        _pieceManager = GetComponent<PieceManager>();
    }

    void Update()
    {
        if (_agentMode.IsInAgentMode) return;
        _pieceObject.position = _controller.MousePosition + _positionCorrection;
    }

    public void SetActualPiece(Piece piece)
    {
        if (!IsAValidSelection(piece)) return;
        if (_pieceObject !=null) Destroy(_pieceObject.gameObject);
        _actualPiece = piece;
        _pieceObject = Instantiate(_actualPiece.PieceSO.PrefabTransform, Vector3.zero, Quaternion.identity);
        SetCorrection();
    }

    private void PlacePieceInGrid(Vector3 mouseWorldPosition)
    {
        _grid.GetXY(mouseWorldPosition, out int x, out int y);
        Vector2Int mousePosition = new Vector2Int(x, y);
        if (!_grid.ValidPositionCheck(mousePosition, _actualPiece)) return;
        _grid.OccupyCells(mousePosition, _actualPiece);

        Vector3 correction = new Vector3(0.5f + _positionCorrection.x, 0.5f + _positionCorrection.y, 0);
        Instantiate(_actualPiece.PieceSO.PrefabTransform,
            _grid.GetWorldPosition(x, y)+correction,
            _pieceObject.localRotation,
            _piecesParent);
        _orderManager.ReduceAmountOfPiece(_actualPiece);
        ChangePieceIfNecessary(_pieceList.IndexOf(_actualPiece));
    }

    public bool PlacePieceInGrid()
    {
        Vector2Int agentPosition = new Vector2Int(_agentPosition.x, _agentPosition.y);
        if (!_grid.ValidPositionCheck(agentPosition, _actualPiece)) return false;
        
        _grid.OccupyCells(agentPosition, _actualPiece);

        Vector3 correction = new Vector3(0.5f + _positionCorrection.x, 0.5f + _positionCorrection.y, 0);
        Instantiate(_actualPiece.PieceSO.PrefabTransform,
            _grid.GetWorldPosition(_agentPosition.x, _agentPosition.y) + correction,
            _pieceObject.localRotation,
            _piecesParent);
        _orderManager.ReduceAmountOfPiece(_actualPiece);
        ChangePieceIfNecessary( _pieceList.IndexOf(_actualPiece));
        return true;
    }

    public void ChangePieceIfNecessary( int pieceIndexInList)
    {
        if (_actualPiece == null) _actualPiece = _pieceManager.PieceList[0];
        if (IsAValidSelection(pieceIndexInList))
        {
            SetActualPiece(_pieceManager.PieceList[pieceIndexInList]);
            return;
        }
        if (pieceIndexInList < _pieceList.Count-1)
            ChangePieceIfNecessary(pieceIndexInList + 1);
        else
            ChangePieceIfNecessary(0);
    }
    public void ChangePieceIfNecessary() => ChangePieceIfNecessary(0);

    public void RotatePiece(float side) 
    {
        Facing facing = _actualPiece.Facing;
        if (side>0) facing = RotateRight(facing);
        else facing = RotateLeft(facing);
        _actualPiece.Facing = facing;

        _pieceObject.Rotate(Vector3.forward, -90f*side);
        SetCorrection();
    }

    public bool RotatePiece(bool isRotatingRight)
    {
        Facing facing = _actualPiece.Facing;
        Facing previousFacing = facing;

        if (isRotatingRight) facing = RotateRight(facing);
        else facing = RotateLeft(facing);
        _actualPiece.Facing = facing;

        if (!IsValidPosition(_agentPosition.x,_agentPosition.y))
        {
            _actualPiece.Facing = previousFacing;
            return false;
        }

        float direction;
        if (isRotatingRight) direction = -90f;
        else direction = 90f;

        _pieceObject.Rotate(Vector3.forward, direction);
        SetCorrection();
        return true;
    }

    void SetCorrection()
    {
        float angle = _pieceObject.localEulerAngles.z;
        if (angle == 0) _positionCorrection = new Vector2(-0.5f, -0.5f);
        if (angle == 90) _positionCorrection = new Vector2(0.5f, -0.5f);
        if (angle == 180) _positionCorrection = new Vector2(0.5f, 0.5f);
        if (angle == 270) _positionCorrection = new Vector2(-0.5f, 0.5f);
    }

    //Agent
    public void MovePieceToLeftBottom()
    {
        _pieceObject.position = _grid.GetWorldPosition(0, 0);
        _agentPosition = Vector2Int.zero;
    }
    public bool IsValidPosition(int x, int y)=> _grid.ValidPositionCheck(new Vector2Int(x, y), _actualPiece);
    public bool IsValidPosition() => _grid.ValidPositionCheck(new Vector2Int(_agentPosition.x, _agentPosition.y), _actualPiece);

    public bool MoveInGrid(int x,int y)
    {
        if (!_grid.IsInsideGrid(_agentPosition.x+x,_agentPosition.y+y)) return false;

        _agentPosition += new Vector2Int(x, y);
        _pieceObject.position = _grid.GetWorldPosition(_agentPosition.x, _agentPosition.y);
        return true;
    }

    public bool IsAValidSelection(Piece piece)
    {
        List<PieceType> pieceTypeList =  _orderManager.AvailablePiecesList;
        PieceType type = pieceTypeList[_pieceList.IndexOf(piece)];
        if (type == PieceType.None)
            return false;
        return true;
    }

    public bool IsAValidSelection(int index)
    {
        List<PieceType> pieceTypeList = _orderManager.AvailablePiecesList;
        PieceType type = pieceTypeList[index];
        if (type == PieceType.None)
            return false;
        return true;
    }

}
