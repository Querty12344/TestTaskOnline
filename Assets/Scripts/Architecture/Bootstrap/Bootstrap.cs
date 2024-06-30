using Architecture.GameStatesLogic;
using Architecture.GameStatesLogic.States;
using Architecture.UI.Mediator;
using Architecture.Utilits;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour, ICoroutineRunner
{
    private Bootstrap _singleton;
    private IStateMachine _stateMachine;
    private IUIMediator _uiMediator;

    private void Start()
    {
        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(gameObject);
            _stateMachine.Enter<BootstrapState>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Inject]
    private void Construct(IStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}