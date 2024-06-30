using Architecture.Online;
using Architecture.UI;
using Architecture.UI.UIElements;
using Constants;
using Photon.Pun;

namespace Architecture.GameStatesLogic.States
{
    public class ClientConnectionState : IState
    {
        private readonly IClientConnection _clientConnection;
        private IStateMachine _stateMachine;
        private readonly IWindowService _windowService;

        public ClientConnectionState(IClientConnection clientConnection, IWindowService windowService)
        {
            _clientConnection = clientConnection;
            _windowService = windowService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _windowService.Clear();
            _windowService.OpenWindow(WindowTypes.ClientConnection);
        }

        public void Connect(string roomName = "")
        {
            _clientConnection.TryConnect(OnSuccessfulConnect, OnFailureConnect, roomName);
        }

        public void BackToChoosingMode()
        {
            _stateMachine.Enter<ModeChoosingState>();
        }

        private void OnSuccessfulConnect()
        {
            MessageUI.Singleton.ShowMessage(MessageTexts.ConnectionSuccessText);
            _stateMachine.Enter<GameControllingState>();
        }

        private void OnFailureConnect(string error)
        {
            MessageUI.Singleton.ShowMessage(MessageTexts.ConnectionErrorText + error);
        }
    }
}