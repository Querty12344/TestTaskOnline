using Architecture.UI;

namespace Architecture.GameStatesLogic.States
{
    public class ControllerWaitingState : IState
    {
        private readonly IInputService _inputService;
        private IStateMachine _stateMachine;
        private readonly IWindowService _windowService;

        public ControllerWaitingState(IWindowService windowService, IInputService inputService)
        {
            _inputService = inputService;
            _windowService = windowService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            InitInterface();
            _inputService.ControllerConnected += OnControllerConnected;
        }

        public void Leave()
        {
            _inputService.ControllerConnected -= OnControllerConnected;
            _stateMachine.Enter<HostLeavingState>();
        }

        private void InitInterface()
        {
            _windowService.Clear();
            _windowService.OpenWindow(WindowTypes.ControllerWaiting);
        }

        private void OnControllerConnected()
        {
            _inputService.ControllerConnected -= OnControllerConnected;
            _stateMachine.Enter<GameLoopState>();
        }
    }
}