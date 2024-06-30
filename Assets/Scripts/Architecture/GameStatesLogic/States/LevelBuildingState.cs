using Architecture.FactoryLogic;
using Architecture.SceneLoading;

namespace Architecture.GameStatesLogic.States
{
    public class LevelBuildingState : IState
    {
        private readonly IGameFactory _gameFactory;
        private readonly IInputService _inputService;
        private readonly ISceneLoader _sceneLoader;
        private IStateMachine _stateMachine;

        public LevelBuildingState(IInputService inputService, ISceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _inputService = inputService;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _sceneLoader.LoadScene(SceneNames.Game, OnGameSceneLoaded);
        }

        private void OnGameSceneLoaded()
        {
            _gameFactory.CreateField();
            _gameFactory.CreatePlayer(_inputService);
            _stateMachine.Enter<ControllerWaitingState>();
        }
    }
}