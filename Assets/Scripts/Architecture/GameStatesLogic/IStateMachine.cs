namespace Architecture.GameStatesLogic
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
    }
}