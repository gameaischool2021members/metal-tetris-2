using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OrdersEnum;

public class PieceTint : MonoBehaviour
{
    Renderer[] _rendererList;

    private void Start()
    {
        _rendererList = GetComponentsInChildren<Renderer>();
    }

    public void Tint(Order orderNumber)
    {
        switch (orderNumber)
        {
            case Order.Order1:
                //_rendererList
                break;
            case Order.Order2:
                break;
            case Order.Order3:
                break;
            default:
                break;
        }
    }


}
