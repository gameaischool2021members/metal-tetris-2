using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] List<Piece> _pieceList;
    PieceSelection _pieceSelection;

    public List<Piece> PieceList  => _pieceList;
    private void Awake() => _pieceSelection = GetComponent<PieceSelection>();
    private void Start()
    {
        _pieceSelection.PieceList = _pieceList;
        GetOrder1Piece0();
        _pieceSelection.ChangePieceIfNecessary();
    }

    public void SetPieceByIndex(int index) => _pieceSelection.SetActualPiece( _pieceList[index]);
    public void GetOrder1Piece0() => SetPieceByIndex(0);
    public void GetOrder1Piece1() => SetPieceByIndex(1);
    public void GetOrder1Piece2() => SetPieceByIndex(2);
    public void GetOrder1Piece3() => SetPieceByIndex(3);
    public void GetOrder2Piece0() => SetPieceByIndex(4);
    public void GetOrder2Piece1() => SetPieceByIndex(5);
    public void GetOrder2Piece2() => SetPieceByIndex(6);
    public void GetOrder2Piece3() => SetPieceByIndex(7);
    public void GetOrder3Piece0() => SetPieceByIndex(8);
    public void GetOrder3Piece1() => SetPieceByIndex(9);
    public void GetOrder3Piece2() => SetPieceByIndex(10);
    public void GetOrder3Piece3() => SetPieceByIndex(11);
}
