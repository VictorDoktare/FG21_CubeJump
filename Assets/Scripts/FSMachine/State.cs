namespace FSMachine
{
    public abstract class State
    {
        public string StateName;
        protected global::FSMachine.FSMachine StateMachine;
    
        public State(string stateName, global::FSMachine.FSMachine stateMachine)
        {
            StateName = stateName;
            StateMachine = stateMachine;
        }
    
        public virtual void Enter() { }
        public virtual void UpdateLogic() { }
        public virtual void UpdatePhysics() { }
        public virtual void Exit() { }
    }
}
