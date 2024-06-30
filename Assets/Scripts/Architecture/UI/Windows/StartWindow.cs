using Architecture.UI.Mediator;

namespace Architecture.RemoteController
{
    public class StartWindow : WindowBase
    {
        private IUIMediator _uiMediator;

        public void Construct(IUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void EnterAsHost()
        {
            _uiMediator.EnterAsHost();
        }

        public void EnterAsClient()
        {
            _uiMediator.EnterAsClient();
        }
    }
}