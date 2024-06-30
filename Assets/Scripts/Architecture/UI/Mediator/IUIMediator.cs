namespace Architecture.UI.Mediator
{
    public interface IUIMediator
    {
        public void BackToChoosingMode();
        public void AutoConnect();
        public void Connect(string name);
        public void EnterAsClient();
        public void EnterAsHost();
        public void LeaveFromWaiting();
        public void LeaveFromGame();
        void LeaveController();
    }
}