using System;
using UnityEngine;

public abstract class FSMachine : MonoBehaviour
{
    protected State State;
    protected string PrevState { get; private set; }

    private void Start()
    {
        State = SetInitialState();

        State?.Enter();
    }
    
    private void Update()
    {
        State?.UpdateLogic();
    }

    private void FixedUpdate()
    {
        State?.UpdatePhysics();
    }
    
    protected virtual State SetInitialState()
    {
        return null;
    }

    public void SetState(State newState)
    {
        PrevState = State.Name;
        State.Exit();
        State = newState;
        newState.Enter();
    }

    public string GetPrevState()
    {
        return PrevState;
    }
}
