public abstract class State
{
    public string Name;
    protected FSMachine StateMachine;
    
    public State(string name, FSMachine stateMachine)
    {
        Name = $"State: {name}";
        StateMachine = stateMachine;
    }
    
    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
