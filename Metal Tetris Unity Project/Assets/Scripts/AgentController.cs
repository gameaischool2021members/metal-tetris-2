using UnityEngine;

public class AgentController : MonoBehaviour
{
    PieceManager _pieceManager;
    PieceSelection _pieceSelection;
    DeliverySystem _deliverySystem;
    public PieceManager PieceManager {set => _pieceManager = value; }
    public PieceSelection PieceSelection {set => _pieceSelection = value; }
    public DeliverySystem DeliverySystem {set => _deliverySystem = value; }

    private void OnEnable()
    {
        if (_pieceSelection == null) return;
        _pieceSelection.MovePieceToLeftBottom();
    }

    //Selecting Piece
    public void SelectOrder1Piece0() => _pieceManager.GetOrder1Piece0();
    public void SelectOrder1Piece1() => _pieceManager.GetOrder1Piece1();
    public void SelectOrder1Piece2() => _pieceManager.GetOrder1Piece2();
    public void SelectOrder1Piece3() => _pieceManager.GetOrder1Piece3();

    public void SelectOrder2Piece0() => _pieceManager.GetOrder2Piece0();
    public void SelectOrder2Piece1() => _pieceManager.GetOrder2Piece1();
    public void SelectOrder2Piece2() => _pieceManager.GetOrder2Piece2();
    public void SelectOrder2Piece3() => _pieceManager.GetOrder2Piece3();

    public void SelectOrder3Piece0() => _pieceManager.GetOrder3Piece0();
    public void SelectOrder3Piece1() => _pieceManager.GetOrder3Piece1();
    public void SelectOrder3Piece2() => _pieceManager.GetOrder3Piece2();
    public void SelectOrder3Piece3() => _pieceManager.GetOrder3Piece3();


    //Rotating Piece
    public bool RotateRight() => _pieceSelection.RotatePiece(true);
    public bool RotateLeft() => _pieceSelection.RotatePiece(false);

    //Move In The Grid
    public bool MoveUp() => _pieceSelection.MoveInGrid(0, 1);
    public bool MoveRight() => _pieceSelection.MoveInGrid(1, 0);
    public bool MoveDown() => _pieceSelection.MoveInGrid(0, -1);
    public bool MoveLeft() => _pieceSelection.MoveInGrid(-1, 0);

    //Place the Piece
    public bool PlacePiece() => _pieceSelection.PlacePieceInGrid();

    //clearing the Sheet
    public void ClearTheSheet() =>_deliverySystem.Deliver();

}
