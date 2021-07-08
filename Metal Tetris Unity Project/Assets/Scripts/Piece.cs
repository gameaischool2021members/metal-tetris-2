using System;
using UnityEngine;
using static Direction;
using static OrdersEnum;

[Serializable]
public class Piece 
{
    [SerializeField] PieceSO _pieceSO;
    [SerializeField] Order _orderNumber;
    [HideInInspector] public Facing Facing;
    public PieceSO PieceSO => _pieceSO;
    public Order OrderNumber =>_orderNumber;
}
