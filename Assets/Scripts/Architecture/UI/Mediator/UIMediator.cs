using Architecture.GameStatesLogic.States;
using Architecture.UI.UIElements;

namespace Architecture.UI.Mediator
{
    public class UIMediator : IUIMediator
    {
        private readonly ControllerWaitingState _controllerWaitingState;
        private readonly GameLoopState _gameLoopState;
        private readonly ModeChoosingState _modeChoosingState;
        private readonly ClientConnectionState _clientConnectionState;
        private readonly GameControllingState _gameControllingState;
        private MessageUI _messageUI;

        public UIMediator(GameControllingState gameControllingState, ModeChoosingState modeChoosingState,
            ClientConnectionState clientConnectionState, ControllerWaitingState controllerWaitingState,
            GameLoopState gameLoopState)
        {
            _gameControllingState = gameControllingState;
            _clientConnectionState = clientConnectionState;
            _controllerWaitingState = controllerWaitingState;
            _gameLoopState = gameLoopState;
            _modeChoosingState = modeChoosingState;
        }

        public void AutoConnect()
        {
            _clientConnectionState.Connect();
        }

        public void Connect(string name)
        {
            _clientConnectionState.Connect(name);
        }

        public void EnterAsClient()
        {
            _modeChoosingState.EnterAsClient();
        }

        public void EnterAsHost()
        {
            _modeChoosingState.EnterAsHost();
        }

        public void BackToChoosingMode()
        {
            _clientConnectionState.BackToChoosingMode();
        }

        public void LeaveFromWaiting()
        {
            _controllerWaitingState.Leave();
        }

        public void LeaveFromGame()
        {
            _gameLoopState.Leave();
        }

        public void LeaveController()
        {
            _gameControllingState.Leave();
        }
    }
}