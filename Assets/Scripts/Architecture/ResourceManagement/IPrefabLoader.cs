using Architecture.RemoteController;
using Gameplay.CubeLogic;
using Gameplay.FieldLogic;
using Gameplay.PlayerLogic;

namespace Architecture.ResourceManagement
{
    public interface IPrefabLoader
    {
        HUDWindow GetHUDWindow();

        public void Load();

        public Field GetField();

        public Cube GetCube();

        public Player GetPlayer();

        public ClientConnectWindow GetClientConnectWindow();

        public StartWindow GetStartWindow();

        public ControllerWaitingWindow GetControllerWaitingWindow();

        public ControllerWindow GetControllerWindow();
    }
}