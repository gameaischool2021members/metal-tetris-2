using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static PieceTypeEnum;

public class OrderOperation : MonoBehaviour
{
    [SerializeField] Piece _piece1, _piece2, _piece3, _piece4;
    [HideInInspector] public float OrderPrice;
    [HideInInspector] public int Piece1Amount, Piece2Amount, Piece3Amount, Piece4Amount;
    [HideInInspector] public bool IsPiece1Empty, IsPiece2Empty, IsPiece3Empty, IsPiece4Empty;



    private void Update()
    {
        
    }




    public void GenerateOrderPrice()
    {
        OrderPrice = 0;
        OrderPrice += (Piece1Amount * _piece1.PieceSO.PiecePrice);
        OrderPrice += (Piece1Amount * _piece2.PieceSO.PiecePrice);
        OrderPrice += (Piece1Amount * _piece3.PieceSO.PiecePrice);
        OrderPrice += (Piece1Amount * _piece4.PieceSO.PiecePrice);
        UpdatePriceText();
    }

    private void UpdatePriceText()
    {
        //throw new NotImplementedException();
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
    }

    void CheckCompletition()
    {
        if (Piece1Amount == 0 && Piece2Amount ==0 && Piece3Amount == 0 && Piece4Amount == 0)
        {
            //doCompletition Stuff
        }
    }
}
