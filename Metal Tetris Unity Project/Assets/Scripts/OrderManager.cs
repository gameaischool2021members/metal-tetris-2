using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PieceTypeEnum;

public class OrderManager : MonoBehaviour
{
    [SerializeField] OrderOperation _order1;
    [SerializeField] OrderOperation _order2;
    [SerializeField] OrderOperation _order3;

    [SerializeField] PieceManager _pieceManager;

    int _actualOrder;

    private void Start()
    {
        GenerateRandomOrder(_order1);
        GenerateRandomOrder(_order2);
        GenerateRandomOrder(_order3);
    }


    void GenerateRandomOrder(OrderOperation order)
    {
        int numberOfPieces = Random.Range(2, 5);
        for (int i = 0; i < numberOfPieces; i++)
        {
            int pieceNumber = Random.Range(1, 5);
            switch (pieceNumber)
            {
                case 1: order.Piece1Amount++;
                    
                    break;
                case 2:
                    order.Piece2Amount++;
                    break;
                case 3:
                    order.Piece3Amount++;
                    break;
                case 4:
                    order.Piece4Amount++;
                    break;
                default:
                    break;
            }
        }
        order.GenerateOrderPrice();
    }

    public void ReduceAmountOfPiece(Piece piece)
    {
        OrderOperation order;
        switch (piece.OrderNumber)
        {
            case OrdersEnum.Order.Order1:
                order = _order1;
                break;
            case OrdersEnum.Order.Order2:
                order = _order2;
                break;
            case OrdersEnum.Order.Order3:
                order = _order3;
                break;
            default:
                order = _order1;
                break;
        }
        order.ReducePieceAmount(piece.PieceSO.PieceType);
    }


}
