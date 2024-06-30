using Architecture.UI.JoysticController;
using Architecture.UI.Mediator;
using UnityEngine;

namespace Architecture.RemoteController
{
    public class ControllerWindow : WindowBase
    {
        [SerializeField] private JoystickController _controller;
        private IUIMediator _uiMediator;

        public IController Controller => _controller;

        public void Construct(IUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void Leave()
        {
            _uiMediator.LeaveController();
        }
    }
}