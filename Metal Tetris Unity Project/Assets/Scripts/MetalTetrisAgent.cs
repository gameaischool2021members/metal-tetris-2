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
    
    private float m_TimeUntilMove;
    private int m_MovesMade;
    private int rowsFilled;
    
    void Start()
    {
        deliverySystem = FindObjectOfType<DeliverySystem>();
        m_AgentWorldStateGetter = FindObjectOfType<AgentWorldStateGetter>();
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
        int[,] gridStatus = m_AgentWorldStateGetter.GridStatus(); //6 x 10
        foreach (var val in gridStatus)
        {
            sensor.AddObservation(val);
        }
        
        sensor.AddObservation(m_AgentWorldStateGetter.PorcentageFilled());
        sensor.AddObservation(m_AgentWorldStateGetter.RowsCompletelyOccupied());
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2


        // Rewards
        AddReward(m_AgentWorldStateGetter.PorcentageFilled());

        int newRowsFilled = m_AgentWorldStateGetter.RowsCompletelyOccupied();
        if(newRowsFilled > rowsFilled)
        {
            rowsFilled = newRowsFilled;
            AddReward(rowsFilled);
        }

        // Reached target


        // Fell off platform
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // var continuousActionsOut = actionsOut.ContinuousActions;
        // continuousActionsOut[0] = Input.GetAxis("Horizontal");
        // continuousActionsOut[1] = Input.GetAxis("Vertical");
    }
}