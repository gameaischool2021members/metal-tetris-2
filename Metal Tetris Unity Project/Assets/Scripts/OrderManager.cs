using System.Collections.Generic;
using UnityEngine;
using static PieceTypeEnum;

public class OrderManager : MonoBehaviour
{
    [SerializeField] OrderOperation _order1;
    [SerializeField] OrderOperation _order2;
    [SerializeField] OrderOperation _order3;

    [SerializeField] PieceManager _pieceManager;

    List<PieceType> _originalTypesList = new List<PieceType>();
    List<PieceType> _availablePiecesList = new List<PieceType>();

    public List<PieceType> AvailablePiecesList => _availablePiecesList; 

    private void Start()
    {
        GenerateRandomOrder(_order1);
        GenerateRandomOrder(_order2);
        GenerateRandomOrder(_order3);
        GenerateOriginalTypesList();
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
        UpdateAvailablePiecesList();
    }

    void GenerateOriginalTypesList()
    {
        List<Piece> pieceList = _pieceManager.PieceList;
        foreach (Piece piece in pieceList)
        {
            _originalTypesList.Add(piece.PieceSO.PieceType);
            _availablePiecesList.Add(piece.PieceSO.PieceType);
        }
        UpdateAvailablePiecesList();
    }

    public void UpdateAvailablePiecesList()
    {
        if (_order1.Piece1Amount == 0) _availablePiecesList[0] = PieceType.None;
        else _availablePiecesList[0] = _originalTypesList[0];
        if (_order1.Piece2Amount == 0) _availablePiecesList[1] = PieceType.None;
        else _availablePiecesList[1] = _originalTypesList[1];
        if (_order1.Piece3Amount == 0) _availablePiecesList[2] = PieceType.None;
        else _availablePiecesList[2] = _originalTypesList[2];
        if (_order1.Piece4Amount == 0) _availablePiecesList[3] = PieceType.None;
        else _availablePiecesList[3] = _originalTypesList[3];

        if (_order2.Piece1Amount == 0) _availablePiecesList[4] = PieceType.None;
        else _availablePiecesList[4] = _originalTypesList[4];
        if (_order2.Piece2Amount == 0) _availablePiecesList[5] = PieceType.None;
        else _availablePiecesList[5] = _originalTypesList[5];
        if (_order2.Piece3Amount == 0) _availablePiecesList[6] = PieceType.None;
        else _availablePiecesList[6] = _originalTypesList[6];
        if (_order2.Piece4Amount == 0) _availablePiecesList[7] = PieceType.None;
        else _availablePiecesList[7] = _originalTypesList[7];

        if (_order3.Piece1Amount == 0) _availablePiecesList[8] = PieceType.None;
        else _availablePiecesList[8] = _originalTypesList[8];
        if (_order3.Piece2Amount == 0) _availablePiecesList[9] = PieceType.None;
        else _availablePiecesList[9] = _originalTypesList[9];
        if (_order3.Piece3Amount == 0) _availablePiecesList[10] = PieceType.None;
        else _availablePiecesList[10] = _originalTypesList[10];
        if (_order3.Piece4Amount == 0) _availablePiecesList[11] = PieceType.None;
        else _availablePiecesList[11] = _originalTypesList[11];
    }
}
