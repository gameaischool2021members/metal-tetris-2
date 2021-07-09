using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGrabber : MonoBehaviour
{
    [SerializeField] PieceManager _pieceManager;
    [SerializeField] int _pieceIndex;

    public void GrabAPiece()
    {

        _pieceManager.SetPieceByIndex(_pieceIndex);
    }
}
