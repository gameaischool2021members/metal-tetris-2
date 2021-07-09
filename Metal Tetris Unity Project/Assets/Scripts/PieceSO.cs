using System.Collections.Generic;
using UnityEngine;
using static PieceTypeEnum;

[CreateAssetMenu(menuName ="Piece")]
public class PieceSO : ScriptableObject
{
    [SerializeField] string _pieceName;
    [SerializeField] PieceType _pieceType;
    [SerializeField] int _piecePrice;
    [SerializeField] Transform _prefabTransform;
    [SerializeField] List<Vector2Int> _coveredCells;
    [SerializeField] Vector2Int _pivotPoint;

    public string PieceName => _pieceName;
    public Transform PrefabTransform => _prefabTransform;
    public List<Vector2Int> CoveredCells => _coveredCells;
    public Vector2Int PivotPoint => _pivotPoint;
    public PieceType PieceType => _pieceType;
    public int PiecePrice => _piecePrice;
}
