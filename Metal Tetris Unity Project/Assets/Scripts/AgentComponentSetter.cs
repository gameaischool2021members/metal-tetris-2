using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentComponentSetter : MonoBehaviour
{
    [SerializeField] AgentController _agentController;
    PieceManager _pieceManager;
    PieceSelection _pieceSelection;
    DeliverySystem _deliverySystem;

    private void Awake()
    {
        _pieceManager = GetComponent<PieceManager>();
        _pieceSelection = GetComponent<PieceSelection>();
        _deliverySystem = GetComponent<DeliverySystem>();
    }

    private void Start()
    {
        _agentController.PieceManager = _pieceManager;
        _agentController.PieceSelection = _pieceSelection;
        _agentController.DeliverySystem = _deliverySystem;
    }
}
