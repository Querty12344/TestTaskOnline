using Architecture.UI.Mediator;

namespace Architecture.RemoteController
{
    public class ControllerWaitingWindow : WindowBase
    {
        private IUIMediator _uiMediator;

        public void Construct(IUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void Leave()
        {
            _uiMediator.LeaveFromWaiting();
        }
    }
}