using Architecture.UI.Mediator;
using TMPro;
using UnityEngine;

namespace Architecture.RemoteController
{
    public class ClientConnectWindow : WindowBase
    {
        [SerializeField] private TMP_InputField _roomNameField;
        private IUIMediator _uiMediator;

        public void Construct(IUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void ConnectByName()
        {
            _uiMediator.Connect(_roomNameField.text);
        }

        public void AutoConnect()
        {
            _uiMediator.AutoConnect();
        }

        public void BackToChoosingMode()
        {
            _uiMediator.BackToChoosingMode();
        }

        public override void Remove()
        {
            Destroy(gameObject);
        }
    }
}