using Architecture.RemoteController;
using Gameplay.CubeLogic;
using Gameplay.FieldLogic;
using Gameplay.PlayerLogic;
using UnityEngine;

namespace Architecture.ResourceManagement
{
    public class PrefabLoader : IPrefabLoader
    {
        private ClientConnectWindow _clientConnectWindow;
        private ControllerWaitingWindow _controllerWaitingWindow;
        private ControllerWindow _controllerWindow;
        private Cube _cube;
        private Field _field;
        private HUDWindow _hudWindow;
        private Player _player;
        private StartWindow _startWindow;

        public void Load()
        {
            _hudWindow = Resources.Load<HUDWindow>(ResourcePath.HUDWindowPath);
            _field = Resources.Load<Field>(ResourcePath.FieldPath);
            _cube = Resources.Load<Cube>(ResourcePath.CubePath);
            _player = Resources.Load<Player>(ResourcePath.PlayerPath);
            _clientConnectWindow = Resources.Load<ClientConnectWindow>(ResourcePath.ClientConnectionWindowPath);
            _startWindow = Resources.Load<StartWindow>(ResourcePath.StartWindowPath);
            _controllerWaitingWindow =
                Resources.Load<ControllerWaitingWindow>(ResourcePath.ControllerWaitingWindowPath);
            _controllerWindow = Resources.Load<ControllerWindow>(ResourcePath.ControllerWindowPath);
        }

        public HUDWindow GetHUDWindow()
        {
            return _hudWindow;
        }

        public Field GetField()
        {
            return _field;
        }

        public Cube GetCube()
        {
            return _cube;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public ClientConnectWindow GetClientConnectWindow()
        {
            return _clientConnectWindow;
        }

        public StartWindow GetStartWindow()
        {
            return _startWindow;
        }

        public ControllerWaitingWindow GetControllerWaitingWindow()
        {
            return _controllerWaitingWindow;
        }

        public ControllerWindow GetControllerWindow()
        {
            return _controllerWindow;
        }
    }
}