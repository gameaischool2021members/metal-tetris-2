using UnityEngine;

public class AgentComponentSetter : MonoBehaviour
{
    [SerializeField] AgentController _agentController;
    [SerializeField] AgentWorldStateGetter _agentWorldStateGetter;
    [SerializeField] OrderManager _orderManager;
    PieceManager _pieceManager;
    PieceSelection _pieceSelection;
    DeliverySystem _deliverySystem;
    RedLineManager _redLineManager;

    GridSystem _grid;

    public GridSystem Grid {set => _grid = value;}

    private void Awake()
    {
        _pieceManager = GetComponent<PieceManager>();
        _pieceSelection = GetComponent<PieceSelection>();
        _deliverySystem = GetComponent<DeliverySystem>();
        _redLineManager = GetComponent<RedLineManager>();
        _agentController.PieceManager = _pieceManager;
        _agentController.PieceSelection = _pieceSelection;
        _agentController.DeliverySystem = _deliverySystem;
        _agentWorldStateGetter.PieceSelection = _pieceSelection;
        _agentWorldStateGetter.RedLineManager = _redLineManager;
        _agentWorldStateGetter.OrderManager = _orderManager;
    }

    private void Start()
    {
        _agentWorldStateGetter.Grid = _grid;
    }
}
