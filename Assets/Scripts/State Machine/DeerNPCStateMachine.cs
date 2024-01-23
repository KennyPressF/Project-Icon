using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class DeerNPCStateMachine : MonoBehaviour
{
    public State currentState;

    public DeerIdleState idleState;
    public DeerSpookedState spookedState;
    public List<State> statesList;

    // Initialize the state machine with the initial state (e.g., IdleState)
    void Start()
    {
        idleState = new DeerIdleState();
        spookedState = new DeerSpookedState();
        statesList = new List<State>();

        statesList.Add(idleState);
        statesList.Add(spookedState);
        ChangeState(idleState);
    }

    //ChangeState
    public void ChangeState(State newState)
    {
        // Exit the current state
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        // Enter the new state
        currentState = newState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateStateLogic(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateStateLogic(this);
    }
}
