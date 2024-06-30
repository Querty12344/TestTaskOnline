using Architecture.UI.Factory;
using Architecture.UI.JoysticController;

namespace Architecture.UI
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void OpenWindow(WindowTypes type)
        {
            switch (type)
            {
                case WindowTypes.ClientConnection:
                    _uiFactory.CreateClientConnectionWindow();
                    break;
                case WindowTypes.ControllerWaiting:
                    _uiFactory.CreateControllerWaitWindow();
                    break;
                case WindowTypes.StartModeChoose:
                    _uiFactory.CreateStartWindow();
                    break;
                case WindowTypes.HUD:
                    _uiFactory.CreateHUDWindow();
                    break;
            }
        }

        public IController CreateController()
        {
            return _uiFactory.CreateController();
        }

        public void Clear()
        {
            _uiFactory.ClearUIPool();
        }
    }
}