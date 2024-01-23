using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void StartState(DeerNPCStateMachine stateMachine);

    public abstract void EnterState(DeerNPCStateMachine stateMachine);

    public abstract void ExitState(DeerNPCStateMachine stateMachine);

    public abstract void UpdateStateLogic(DeerNPCStateMachine stateMachine);

    public abstract void FixedUpdateStateLogic(DeerNPCStateMachine enemyStateMachine);

    
}
