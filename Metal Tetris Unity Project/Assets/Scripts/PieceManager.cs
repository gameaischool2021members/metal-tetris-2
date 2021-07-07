using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [SerializeField] List<Piece> _pieceList;
    PieceSelection _pieceSelection;

    private void Awake() => _pieceSelection = GetComponent<PieceSelection>();
    private void Start() => GetPiece0();

    void SetPieceByIndex(int index) => _pieceSelection.SetActualPiece( _pieceList[index]);
    public void GetPiece0() => SetPieceByIndex(0);
    public void GetPiece1() => SetPieceByIndex(1);
    public void GetPiece2() => SetPieceByIndex(2);
    public void GetPiece3() => SetPieceByIndex(3);
}
