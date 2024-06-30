using Architecture.UI;
using Architecture.Utilits;

namespace Architecture.GameStatesLogic.States
{
    public class GameLoopState : IState
    {
        private readonly IApplicationStateListener _applicationState;
        private readonly IInputService _inputService;
        private IStateMachine _stateMachine;
        private readonly IWindowService _windowService;

        public GameLoopState(IInputService inputService, IWindowService windowService,
            IApplicationStateListener applicationState)
        {
            _inputService = inputService;
            _windowService = windowService;
            _applicationState = applicationState;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _inputService.ControllerDisconnected += OnControllerDisconnected;
            _applicationState.QuitApplication += Leave;
            _windowService.Clear();
            _windowService.OpenWindow(WindowTypes.HUD);
        }

        public void Leave()
        {
            _inputService.ControllerDisconnected -= OnControllerDisconnected;
            _applicationState.QuitApplication -= Leave;
            _stateMachine.Enter<HostLeavingState>();
        }

        private void OnControllerDisconnected()
        {
            _applicationState.QuitApplication -= Leave;
            _inputService.ControllerDisconnected -= OnControllerDisconnected;
            _stateMachine.Enter<ControllerWaitingState>();
        }
    }
}