using Architecture.UI.JoysticController;

namespace Architecture.UI
{
    public interface IWindowService
    {
        public void OpenWindow(WindowTypes type);
        public IController CreateController();
        void Clear();
    }
}