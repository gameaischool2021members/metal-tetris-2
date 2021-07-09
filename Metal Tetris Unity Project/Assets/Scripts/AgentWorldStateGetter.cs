using System.Collections.Generic;
using UnityEngine;
using static Direction;
using static PieceTypeEnum;

public class AgentWorldStateGetter : MonoBehaviour
{
    GridSystem _grid;
    PieceSelection _pieceSelection;
    RedLineManager _redLineManager;
    OrderManager _orderManager;

    public GridSystem Grid {set => _grid = value; }
    public PieceSelection PieceSelection {set => _pieceSelection = value; }
    public RedLineManager RedLineManager {set => _redLineManager = value; }
    public OrderManager OrderManager {set => _orderManager = value; }

    //Grid Status
    public int[,] GridStatus()
    {
        _grid.GetGridDimensions(out int width, out int height);
        int[,] gridStatus = new int[width,height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                gridStatus[x,y]= _grid.GetValue(x, y);
            }
        }
        return gridStatus;
    }

    //percentage filled
    public float PorcentageFilled() => _grid.OccupiedPorcentage();

    //rowscompletely ocuppied
    public int RowsCompletelyOccupied()
    {
        int filledRows = 0;

        _grid.GetGridDimensions(out int width, out int height);

        for (int y = 0; y < height; y++)
        {
            int numberOfCellsOccupied = 0;
            for (int x = 0; x < width; x++)
            {
                if (_grid.GetValue(x, y) != 0)
                    numberOfCellsOccupied++;
            }
            if (numberOfCellsOccupied == width)
                filledRows++;
            else
                return filledRows;
        }
        return filledRows;
    }

    //ActualPiecetype
    public PieceType ActualPieceType() => _pieceSelection.ActualPiece.PieceSO.PieceType;

    //ActualRotation
    public Facing ActualRotation() => _pieceSelection.ActualPiece.Facing;

    //Available Pieces
    public List<PieceType> AvailablePieces() => _orderManager.AvailablePiecesList;

    //ActualCost
    public int ActualCost() => _redLineManager.ActualCost;



}
