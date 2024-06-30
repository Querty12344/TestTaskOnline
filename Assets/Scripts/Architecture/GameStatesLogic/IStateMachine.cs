using System;
using System.Collections.Generic;
using Architecture.GameStatesLogic.States;

namespace Architecture.GameStatesLogic
{
    public interface IStateMachine
    {
        void Enter<TState>() where TState : IState;
    }

    internal class StateMachine : IStateMachine
    {
        private IState _active;
        private readonly Dictionary<Type, IState> _states;

        public StateMachine(BootstrapState bootstrapState,
            ClientConnectionState clientConnectionState,
            ControllerWaitingState controllerWaitingState,
            GameControllingState gameControllingState,
            GameLoopState gameLoopState,
            HostLeavingState leaveLevelState,
            ModeChoosingState modeChoosingState,
            LevelBuildingState levelBuildingState)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LevelBuildingState)] = levelBuildingState,
                [typeof(BootstrapState)] = bootstrapState,
                [typeof(ClientConnectionState)] = clientConnectionState,
                [typeof(ControllerWaitingState)] = controllerWaitingState,
                [typeof(GameControllingState)] = gameControllingState,
                [typeof(GameLoopState)] = gameLoopState,
                [typeof(HostLeavingState)] = leaveLevelState,
                [typeof(ModeChoosingState)] = modeChoosingState
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _active = _states[typeof(TState)];
            _active.Enter(this);
        }
    }
}