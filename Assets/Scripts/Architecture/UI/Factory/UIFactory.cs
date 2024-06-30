using System.Collections.Generic;
using Architecture.RemoteController;
using Architecture.ResourceManagement;
using Architecture.UI.JoysticController;
using Architecture.UI.Mediator;
using UnityEngine;
using Zenject;

namespace Architecture.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _diContainer;
        private readonly List<WindowBase> _openedWindows = new();
        private readonly IPrefabLoader _prefabLoader;
        private IUIMediator _uiMediator;

        public UIFactory(IPrefabLoader prefabLoader, DiContainer diContainer)
        {
            _diContainer = diContainer;
            _prefabLoader = prefabLoader;
        }

        public void SetUIMediator()
        {
            _uiMediator = _diContainer.Resolve<IUIMediator>();
        }

        public void CreateControllerWaitWindow()
        {
            var prefab = _prefabLoader.GetControllerWaitingWindow();
            ControllerWaitingWindow controllerWaitWindow;
            controllerWaitWindow = Object.Instantiate(prefab);
            controllerWaitWindow.Construct(_uiMediator);
            _openedWindows.Add(controllerWaitWindow);
        }

        public IController CreateController()
        {
            var prefab = _prefabLoader.GetControllerWindow();
            var controllerWindow = Object.Instantiate(prefab);
            controllerWindow.Construct(_uiMediator);
            _openedWindows.Add(controllerWindow);
            return controllerWindow.Controller;
        }

        public void CreateStartWindow()
        {
            var prefab = _prefabLoader.GetStartWindow();
            var startWindow = Object.Instantiate(prefab);
            startWindow.Construct(_uiMediator);
            _openedWindows.Add(startWindow);
        }


        public void CreateClientConnectionWindow()
        {
            var prefab = _prefabLoader.GetClientConnectWindow();
            var clientConnectionWindow = Object.Instantiate(prefab);
            clientConnectionWindow.Construct(_uiMediator);
            _openedWindows.Add(clientConnectionWindow);
        }

        public void CreateHUDWindow()
        {
            var prefab = _prefabLoader.GetHUDWindow();
            var hudWindow = Object.Instantiate(prefab);
            hudWindow.Construct(_uiMediator);
            _openedWindows.Add(hudWindow);
        }

        public void ClearUIPool()
        {
            foreach (var window in _openedWindows) window?.Remove();
            _openedWindows.Clear();
        }
    }
}