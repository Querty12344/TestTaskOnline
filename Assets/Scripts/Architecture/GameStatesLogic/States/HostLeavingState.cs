using Architecture.RemoteController;
using Architecture.SceneLoading;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Architecture.GameStatesLogic.States
{
    public class HostLeavingState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private IStateMachine _stateMachine;

        public HostLeavingState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            LeaveRoom();
            _sceneLoader.LoadScene(SceneNames.Lobby, OnLobbyLoaded);
        }

        private void OnLobbyLoaded()
        {
            _stateMachine.Enter<ModeChoosingState>();
        }

        private void LeaveRoom()
        {
            var options = new RaiseEventOptions { Receivers = ReceiverGroup.Others };
            var sendOptions = SendOptions.SendReliable;
            PhotonNetwork.RaiseEvent((int)PhotonEvents.HostLeaved, null, options, sendOptions);
            PhotonNetwork.LeaveRoom();
        }
    }
}