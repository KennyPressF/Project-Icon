using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DeerIdleState : State
{
    //This acts as the Start function
    public override void StartState(DeerNPCStateMachine stateMachine)
    {
        
    }

    //This happens when you enter the state, not necessarily for the first time
    public override void EnterState(DeerNPCStateMachine stateMachine)
    {
        Debug.Log($"Enemy: {stateMachine.gameObject.name} entered state: {stateMachine.currentState}");
    }

    //This is called when you start to transition to a new state
    public override void ExitState(DeerNPCStateMachine stateMachine)
    {
        Debug.Log($"Enemy: {stateMachine.gameObject.name} exited state: {stateMachine.currentState}");
    }

    //This acts as Update
    public override void UpdateStateLogic(DeerNPCStateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeerSpookedState state = stateMachine.spookedState;
            stateMachine.ChangeState(state);
        }
    }

    //This acts as Fixed Update
    public override void FixedUpdateStateLogic(DeerNPCStateMachine enemyStateMachine)
    {
    }
}
