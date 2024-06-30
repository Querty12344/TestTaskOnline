using Architecture.Online;
using Architecture.RemoteController;
using Architecture.UI;
using Architecture.UI.UIElements;
using Architecture.Utilits;
using Constants;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.GameStatesLogic.States
{
    public class GameControllingState : IState, IOnEventCallback
    {
        private readonly IApplicationStateListener _applicationStateListener;
        private readonly IClientConnection _clientConnection;
        private readonly IInputService _inputService;
        private IStateMachine _stateMachine;
        private readonly IWindowService _windowService;

        public GameControllingState(IApplicationStateListener applicationStateListener, IWindowService windowService,
            IClientConnection clientConnection, IInputService inputService)
        {
            _applicationStateListener = applicationStateListener;
            _inputService = inputService;
            _clientConnection = clientConnection;
            clientConnection.Disconnect += OnDisconnect;
            _windowService = windowService;
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code == (int)PhotonEvents.HostLeaved)
            {
                Leave();
                MessageUI.Singleton.ShowMessage(MessageTexts.HostLeave);
            }
        }

        public void Enter(IStateMachine stateMachine)
        {
            _applicationStateListener.QuitApplication += Leave;
            _stateMachine = stateMachine;
            _windowService.Clear();
            var controller = _windowService.CreateController();

            _inputService.SetController(controller);
        }

        private void OnDisconnect()
        {
            _applicationStateListener.QuitApplication -= Leave;
            _inputService.RemoveController();
            _clientConnection.Disconnect -= OnDisconnect;
            PhotonNetwork.LeaveRoom();
            _stateMachine.Enter<ClientConnectionState>();
        }

        public void Leave()
        {
            OnDisconnect();
        }
    }
}