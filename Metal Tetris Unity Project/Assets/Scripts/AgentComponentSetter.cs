using UnityEngine;

public class AgentComponentSetter : MonoBehaviour
{
    [SerializeField] AgentController _agentController;
    [SerializeField] AgentWorldStateGetter _agentWorldStateGetter;
    PieceManager _pieceManager;
    PieceSelection _pieceSelection;
    DeliverySystem _deliverySystem;

    GridSystem _grid;

    public GridSystem Grid {set => _grid = value;}

    private void Awake()
    {
        _pieceManager = GetComponent<PieceManager>();
        _pieceSelection = GetComponent<PieceSelection>();
        _deliverySystem = GetComponent<DeliverySystem>();
        _agentController.PieceManager = _pieceManager;
        _agentController.PieceSelection = _pieceSelection;
        _agentController.DeliverySystem = _deliverySystem;
        _agentWorldStateGetter.Grid = _grid;
    }
}
