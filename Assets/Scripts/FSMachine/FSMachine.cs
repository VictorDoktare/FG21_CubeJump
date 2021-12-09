using System;
using UnityEngine;

public abstract class FSMachine : MonoBehaviour
{
    protected State State;

    private void Start()
    {
        State = SetInitialState();

        if (State != null)
        {
            State.Enter();
        }
    }
    
    private void Update()
    {
        if (State != null)
        {
            State.UpdateLogic();
        }
    }

    private void FixedUpdate()
    {
        if (State != null)
        {
            State.UpdatePhysics();
        }
    }
    
    protected virtual State SetInitialState()
    {
        return null;
    }
    
    protected virtual State GetCurrentState()
    {
        return State;
    }
    
    public void SetState(State newState)
    {
        State.Exit();
        State = newState;
        State.Enter();
    }
}
