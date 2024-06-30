using Architecture.FactoryLogic;
using Architecture.GameStatesLogic;
using Architecture.GameStatesLogic.States;
using Architecture.Online;
using Architecture.RemoteController;
using Architecture.ResourceManagement;
using Architecture.SceneLoading;
using Architecture.UI;
using Architecture.UI.Factory;
using Architecture.UI.Mediator;
using Architecture.Utilits;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private Bootstrap _bootstrap;
    [SerializeField] private ApplicationStateListener _applicationState;
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private InputService _inputService;

    public override void InstallBindings()
    {
        BindInfrastructure();
        BindOnlineServices();
        BindFactories();
        BindStates();
    }

    private void BindFactories()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
    }

    private void BindInfrastructure()
    {
        Container.Bind<IApplicationStateListener>().FromInstance(_applicationState).AsSingle();
        Container.Bind<ICoroutineRunner>().FromInstance(_bootstrap).AsSingle();
        Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        Container.Bind<IPrefabLoader>().To<PrefabLoader>().AsSingle();
        Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        Container.Bind<IWindowService>().To<WindowService>().AsSingle();
        Container.Bind<IUIMediator>().To<UIMediator>().AsSingle();
    }

    private void BindOnlineServices()
    {
        Container.Bind<PhotonView>().FromInstance(_photonView).AsSingle();
        Container.Bind<IClientConnection>().To<ClientConnection>().AsSingle();
        Container.Bind<INetworkConnector>().To<NetworkConnector>().AsSingle();
        Container.Bind<IRoomCreator>().To<RoomCreator>().AsSingle();
        Container.Bind<IInputService>().FromInstance(_inputService).AsSingle();
    }

    private void BindStates()
    {
        Container.Bind<BootstrapState>().AsSingle();
        Container.Bind<ClientConnectionState>().AsSingle();
        Container.Bind<ControllerWaitingState>().AsSingle();
        Container.Bind<GameControllingState>().AsSingle();
        Container.Bind<GameLoopState>().AsSingle();
        Container.Bind<HostLeavingState>().AsSingle();
        Container.Bind<LevelBuildingState>().AsSingle();
        Container.Bind<ModeChoosingState>().AsSingle();
    }
}