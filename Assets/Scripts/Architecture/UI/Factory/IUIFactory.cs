using Architecture.UI.JoysticController;

namespace Architecture.UI.Factory
{
    public interface IUIFactory
    {
        void SetUIMediator();

        public void CreateControllerWaitWindow();

        public IController CreateController();

        public void CreateStartWindow();

        public void CreateClientConnectionWindow();

        public void ClearUIPool();

        public void CreateHUDWindow();
    }
}