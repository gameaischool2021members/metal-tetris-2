using System;
using UnityEngine;
using static Direction;

[Serializable]
public class Piece 
{
    [SerializeField] PieceSO _pieceSO;
    [HideInInspector] public Facing Facing;
    public PieceSO PieceSO => _pieceSO;
}
