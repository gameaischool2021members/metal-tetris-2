using UnityEngine;
using TMPro;
using static PieceTypeEnum;
using System;

public class OrderOperation : MonoBehaviour
{
    [SerializeField] Piece _piece1, _piece2, _piece3, _piece4;
    [SerializeField] TMP_Text _priceText;
    [SerializeField] TMP_Text _piece1AmountText, _piece2AmountText, _piece3AmountText, _piece4AmountText;
    [SerializeField] AccountBalance _accountBalance;
    [HideInInspector] public int OrderPrice;
    [HideInInspector] public int Piece1Amount, Piece2Amount, Piece3Amount, Piece4Amount;
    [HideInInspector] public bool IsPiece1Empty, IsPiece2Empty, IsPiece3Empty, IsPiece4Empty;
    public Action<OrderOperation> OrderComplete; 

    public void GenerateOrderPrice()
    {
        OrderPrice = 0;
        OrderPrice += (Piece1Amount * _piece1.PieceSO.PiecePrice);
        OrderPrice += (Piece2Amount * _piece2.PieceSO.PiecePrice);
        OrderPrice += (Piece3Amount * _piece3.PieceSO.PiecePrice);
        OrderPrice += (Piece4Amount * _piece4.PieceSO.PiecePrice);
        UpdatePriceText();
    }

    public void UpdatePriceText() => _priceText.text = OrderPrice.ToString();
    public void UpdatePieceAmountText()
    {
        _piece1AmountText.text = Piece1Amount.ToString();
        _piece2AmountText.text = Piece2Amount.ToString();
        _piece3AmountText.text = Piece3Amount.ToString();
        _piece4AmountText.text = Piece4Amount.ToString();
    }

    public void UpdateEmptinessOfAPiece()
    {
        if (Piece1Amount == 0) IsPiece1Empty = true;
        else IsPiece1Empty = false;

        if (Piece2Amount == 0) IsPiece2Empty = true;
        else IsPiece2Empty = false;

        if (Piece3Amount == 0) IsPiece3Empty = true;
        else IsPiece3Empty = false;

        if (Piece4Amount == 0) IsPiece4Empty = true;
        else IsPiece4Empty = false;
    }

    public void ReducePieceAmount(PieceType pieceType)
    {
        switch (pieceType)
        {
            case PieceType.Frame:
                Piece1Amount--;
                break;
            case PieceType.L_Type:
                Piece2Amount--;
                break;
            case PieceType.T_Type:
                Piece3Amount--;
                break;
            case PieceType.C_Type:
                Piece4Amount--;
                break;
            default:
                Piece1Amount--;
                break;
        }
        CheckCompletition();
        UpdatePieceAmountText();
        UpdateEmptinessOfAPiece();
    }

    void CheckCompletition()
    {
        if (Piece1Amount == 0 && Piece2Amount ==0 && Piece3Amount == 0 && Piece4Amount == 0)
        {
            Debug.Log("Order Completed");
            OrderComplete.Invoke(this);
            _accountBalance.AddToBalance(OrderPrice);
        }
    }

    public bool CheckIfRemaining(Piece piece)
    {
        if (piece.PieceSO.PieceType == _piece1.PieceSO.PieceType)
            return !IsPiece1Empty;
        if (piece.PieceSO.PieceType == _piece2.PieceSO.PieceType)
            return !IsPiece2Empty;
        if (piece.PieceSO.PieceType == _piece3.PieceSO.PieceType)
            return !IsPiece3Empty;
        if (piece.PieceSO.PieceType == _piece4.PieceSO.PieceType)
            return !IsPiece4Empty;
        else
            return false;
    }
}
