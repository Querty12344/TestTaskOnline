using Architecture.Online;
using Architecture.SceneLoading;
using Architecture.UI;
using Architecture.UI.UIElements;
using Architecture.Utilits;
using Constants;

namespace Architecture.GameStatesLogic.States
{
    public class ModeChoosingState : IState
    {
        private readonly IRoomCreator _roomCreator;
        private readonly ISceneLoader _sceneLoader;
        private readonly IWindowService _windowService;
        private IStateMachine _stateMachine;

        public ModeChoosingState(IRoomCreator roomCreator, IWindowService windowService, ISceneLoader sceneLoader)
        {
            _roomCreator = roomCreator;
            _windowService = windowService;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _windowService.Clear();
            _windowService.OpenWindow(WindowTypes.StartModeChoose);
        }

        public void EnterAsHost()
        {
            _roomCreator.CreateRoom(OnRoomCreated, OnCreatingFail, RoomNameGenerator.GetRoomName());
        }

        public void EnterAsClient()
        {
            _stateMachine.Enter<ClientConnectionState>();
        }

        private void OnRoomCreated()
        {
            MessageUI.Singleton.ShowMessage(MessageTexts.HostCreated);
            _sceneLoader.LoadScene(SceneNames.Game, StartControllerWaiting);
        }

        private void StartControllerWaiting()
        {
            _stateMachine.Enter<LevelBuildingState>();
        }

        private void OnCreatingFail(string error)
        {
            MessageUI.Singleton.ShowMessage(MessageTexts.HostErrorText + error);
        }
    }
}