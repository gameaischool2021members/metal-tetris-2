using System;
using System.Collections.Generic;
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

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = ?
        int pieceSelection = actionBuffers.DiscreteActions[0];
        int movement = actionBuffers.DiscreteActions[1];
        int rotation = actionBuffers.DiscreteActions[3];
        int clearSheet = actionBuffers.DiscreteActions[4];

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

        // Reached target
        if (true)
        {
            EndEpisode();
        }
        // Fell off platform
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // var continuousActionsOut = actionsOut.ContinuousActions;
        // continuousActionsOut[0] = Input.GetAxis("Horizontal");
        // continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}