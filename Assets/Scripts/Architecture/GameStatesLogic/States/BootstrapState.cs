using Architecture.Online;
using Architecture.ResourceManagement;
using Architecture.SceneLoading;
using Architecture.UI.Factory;
using Architecture.UI.UIElements;
using Constants;
using Photon.Pun;

namespace Architecture.GameStatesLogic.States
{
    public class BootstrapState : IState
    {
        private readonly INetworkConnector _networkConnector;
        private readonly IPrefabLoader _prefabLoader;
        private readonly ISceneLoader _sceneLoader;
        private readonly IClientConnection _clientConnection;
        private readonly GameControllingState _gameControllingState;
        private readonly IInputService _inputService;
        private readonly IRoomCreator _roomCreator;
        private IStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;

        public BootstrapState(GameControllingState gameControllingState, IInputService inputService,
            IUIFactory uiFactory, ISceneLoader sceneLoader, IPrefabLoader prefabLoader,
            INetworkConnector networkConnector, IClientConnection clientConnection, IRoomCreator roomCreator)
        {
            _inputService = inputService;
            _gameControllingState = gameControllingState;
            _roomCreator = roomCreator;
            _clientConnection = clientConnection;
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
            _prefabLoader = prefabLoader;
            _networkConnector = networkConnector;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            InitServices();
            _sceneLoader.LoadScene(SceneNames.Boot, OnBootSceneLoaded);
        }

        private void OnBootSceneLoaded()
        {
            _networkConnector.StartConnect(OnConnect, OnFailConnect);
        }

        private void OnConnect()
        {
            _sceneLoader.LoadScene(SceneNames.Lobby, EnterChooseModeState);
        }

        private void EnterChooseModeState()
        {
            _stateMachine.Enter<ModeChoosingState>();
        }

        private void OnFailConnect(string error)
        {
            MessageUI.Singleton.ShowMessage(MessageTexts.ConnectionErrorText + error);
        }

        private void InitServices()
        {
            _prefabLoader.Load();
            _uiFactory.SetUIMediator();
            PhotonNetwork.AddCallbackTarget(_networkConnector);
            PhotonNetwork.AddCallbackTarget(_gameControllingState);
            PhotonNetwork.AddCallbackTarget(_roomCreator);
            PhotonNetwork.AddCallbackTarget(_clientConnection);
            PhotonNetwork.AddCallbackTarget(_inputService);
        }
    }
}