namespace Architecture.GameStatesLogic
{
    public interface IState
    {
        void Enter(IStateMachine stateMachine);
    }
}