using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MetalTetrisAgent : Agent
{
    
    [SerializeField, Range(0.01f, 1f)] float moveTime = 0.1f;
    
    private DeliverySystem deliverySystem;
    private AgentWorldStateGetter m_AgentWorldStateGetter;
    private AgentController m_AgentController;
    
    private float m_TimeUntilMove;
    private int m_MovesMade;
    private int rowsFilled;
    
    void Start()
    {
        deliverySystem = FindObjectOfType<DeliverySystem>();
        m_AgentWorldStateGetter = FindObjectOfType<AgentWorldStateGetter>();
        m_AgentController = FindObjectOfType<AgentController>();
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
        
        deliverySystem.ClearGrid();
        m_TimeUntilMove = moveTime;
        rowsFilled = 0;
        m_MovesMade = 0;
        //Reset the Agent when needed

        //Perform a certain action
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        int[,] gridStatus = m_AgentWorldStateGetter.GridStatus(); //6 x 10 = 60
        foreach (var val in gridStatus)
        {
            sensor.AddObservation(val);
        }
        
        sensor.AddObservation(m_AgentWorldStateGetter.PorcentageFilled()); //61
        sensor.AddObservation(m_AgentWorldStateGetter.RowsCompletelyOccupied()); //62
        sensor.AddObservation(m_AgentWorldStateGetter.ActualCost()/100f); //63

        int[] direction = {0, 0, 0, 0}; 

        switch (m_AgentWorldStateGetter.ActualRotation())
        {
            case Direction.Facing.Up:
                direction[0] = 1;
                break;
            case Direction.Facing.Right:
                direction[1] = 1;
                break;
            case Direction.Facing.Down:
                direction[2] = 1;
                break;
            case Direction.Facing.Left:
                direction[3] = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        foreach (var val in direction)
        {
            sensor.AddObservation(val);
        } //67
        
        int[] piece = {0, 0, 0, 0, 0};

        switch (m_AgentWorldStateGetter.ActualPieceType())
        {
            case PieceTypeEnum.PieceType.Frame:
                piece[0] = 1;
                break;
            case PieceTypeEnum.PieceType.L_Type:
                piece[1] = 1;
                break;
            case PieceTypeEnum.PieceType.T_Type:
                piece[2] = 1;
                break;
            case PieceTypeEnum.PieceType.C_Type:
                piece[3] = 1;
                break;
            case PieceTypeEnum.PieceType.None:
                piece[4] = 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        foreach (var val in piece)
        {
            sensor.AddObservation(val);
        } //72

        int[] pieceAvailable = {0, 0, 0, 0};
        
        var listOfAvailablePieces = m_AgentWorldStateGetter.AvailablePieces().ToArray().Distinct().ToArray();

        if (listOfAvailablePieces.Contains(PieceTypeEnum.PieceType.Frame))
        {
            pieceAvailable[0] = 1;
        }

        if (listOfAvailablePieces.Contains(PieceTypeEnum.PieceType.C_Type))
        {
            pieceAvailable[1] = 1;
        }

        if (listOfAvailablePieces.Contains(PieceTypeEnum.PieceType.L_Type))
        {
            pieceAvailable[2] = 1;
        }

        if (listOfAvailablePieces.Contains(PieceTypeEnum.PieceType.T_Type))
        {
            pieceAvailable[3] = 1;
        }


        foreach (var val in pieceAvailable)
        {
            sensor.AddObservation(val);
        } //76

    }
    public override void WriteDiscreteActionMask(IDiscreteActionMask actionMask)
    {
        if (m_AgentWorldStateGetter.ActualPieceType() == PieceTypeEnum.PieceType.None)
        {
            actionMask.SetActionEnabled(1, 0, false);
            actionMask.SetActionEnabled(1, 1, false);
            actionMask.SetActionEnabled(1, 2, false);
            actionMask.SetActionEnabled(1, 3, false);
            actionMask.SetActionEnabled(2, 0, false);
            actionMask.SetActionEnabled(2, 1, false);
            actionMask.SetActionEnabled(3, 0, false);
            actionMask.SetActionEnabled(3, 1, false);
        }
        else
        {
            actionMask.SetActionEnabled(0, 0, false);
            actionMask.SetActionEnabled(0, 1, false);
            actionMask.SetActionEnabled(0, 2, false);
            actionMask.SetActionEnabled(0, 3, false);
            actionMask.SetActionEnabled(0, 4, false);
            actionMask.SetActionEnabled(0, 5, false);
            actionMask.SetActionEnabled(0, 6, false);
            actionMask.SetActionEnabled(0, 7, false);
            actionMask.SetActionEnabled(0, 8, false);
            actionMask.SetActionEnabled(0, 9, false);
            actionMask.SetActionEnabled(0, 10, false);
            actionMask.SetActionEnabled(0, 11, false);
            actionMask.SetActionEnabled(0, 12, false);
        }
    }
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = ?
        int pieceSelection = actionBuffers.DiscreteActions[0];
        int movement = actionBuffers.DiscreteActions[1];
        int rotation = actionBuffers.DiscreteActions[2];
        int clearSheet = actionBuffers.DiscreteActions[3];

        bool res = false;

        switch (pieceSelection)
        {
            case 1:
                m_AgentController.SelectOrder1Piece0();
                break;
            case 2:
                m_AgentController.SelectOrder1Piece1();
                break;
            case 3:
                m_AgentController.SelectOrder1Piece2();
                break;
            case 4:
                m_AgentController.SelectOrder1Piece3();
                break;
            case 5:
                m_AgentController.SelectOrder2Piece0();
                break;
            case 6:
                m_AgentController.SelectOrder2Piece1();
                break;
            case 7:
                m_AgentController.SelectOrder2Piece2();
                break;
            case 8:
                m_AgentController.SelectOrder2Piece3();
                break;
            case 9:
                m_AgentController.SelectOrder3Piece0();
                break;
            case 10:
                m_AgentController.SelectOrder3Piece1();
                break;
            case 11:
                m_AgentController.SelectOrder3Piece2();
                break;
            case 12:
                m_AgentController.SelectOrder3Piece3();
                break;
            case 13:
                break;
        }

        switch (movement)
        {
            case 1:
                res =m_AgentController.MoveUp();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 2:
                res =m_AgentController.MoveDown();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 3:
                res =m_AgentController.MoveLeft();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 4:
                res =m_AgentController.MoveRight();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 5:
                break;
        }
        
        switch (rotation)
        {
            case 1:
                res = m_AgentController.RotateLeft();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 2:
                res = m_AgentController.RotateRight();
                if (res == false)
                    SetReward(-0.2f);
                break;
            case 3:
                break;
        }

        switch (clearSheet)
        {
            case 1:
                res = m_AgentController.PlacePiece();
                if(res == false)
                    SetReward(-0.2f);
                else
                    SetReward(0.1f);
                break;
            case 2:
                m_AgentController.ClearTheSheet();
                EndEpisode();
                break;
            case 3:
                break;
        }
        
        m_MovesMade++;

        // Rewards
        AddReward(m_AgentWorldStateGetter.PorcentageFilled());

        int newRowsFilled = m_AgentWorldStateGetter.RowsCompletelyOccupied();
        if(newRowsFilled > rowsFilled)
        {
            rowsFilled = newRowsFilled;
            AddReward(rowsFilled);
        }
        
        AddReward(m_MovesMade * -0.01f);

        // // Reached target
        // if (true)
        // {
        //     EndEpisode();
        // }
        // // Fell off platform
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // var continuousActionsOut = actionsOut.ContinuousActions;
        // continuousActionsOut[0] = Input.GetAxis("Horizontal");
        // continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}