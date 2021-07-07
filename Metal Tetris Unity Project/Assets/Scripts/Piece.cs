using System;
using UnityEngine;
using static Direction;

[Serializable]
public class Piece 
{
    [SerializeField] PieceSO _pieceSO;
    public Facing Facing;
    public PieceSO PieceSO => _pieceSO;
}
