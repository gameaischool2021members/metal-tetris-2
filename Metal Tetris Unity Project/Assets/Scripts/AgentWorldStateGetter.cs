using UnityEngine;
using static Direction;

public class AgentWorldStateGetter : MonoBehaviour
{
    GridSystem _grid;
    PieceSelection _pieceSelection;
    RedLineManager _redLineManager;

    public GridSystem Grid {set => _grid = value; }
    public PieceSelection PieceSelection {set => _pieceSelection = value; }
    public RedLineManager RedLineManager {set => _redLineManager = value; }

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

    //ActualRotation
    public Facing ActualRotation() => _pieceSelection.ActualPiece.Facing;

    //Available Shapes


    //ActualCost
    public int ActualCost() => _redLineManager.ActualCost;


}
