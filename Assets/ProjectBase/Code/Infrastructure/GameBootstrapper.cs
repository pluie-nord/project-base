using ProjectBase.Code.Infrastructure.StateMachine;
using ProjectBase.Code.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace ProjectBase.Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(gameObject);
        }
    }
}