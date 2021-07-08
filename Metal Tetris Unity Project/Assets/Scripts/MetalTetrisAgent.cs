using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MetalTetrisAgent : Agent
{
    
    [SerializeField, Range(0.01f, 1f)] float moveTime = 0.1f;
    
    private DeliverySystem deliverySystem;
    //Match3Board Board;
    
    private float m_TimeUntilMove;
    private int m_MovesMade;
    
    void Start()
    {
        deliverySystem = FindObjectOfType<DeliverySystem>();
        
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
        
        deliverySystem.ClearGrid();
        m_TimeUntilMove = moveTime;
        m_MovesMade = 0;
        //Reset the Agent when needed

        //Perform a certain action
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //do nothing
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Actions, size = 2


        // Rewards


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