using SkyCastleSkillbox.Code.Infrastructure.Data;
using SkyCastleSkillbox.Code.Infrastructure.Services.SceneContext;
using SkyCastleSkillbox.Code.Infrastructure.Services.SceneLoaderService;
using SkyCastleSkillbox.Code.Infrastructure.Services.StaticData;
using SkyCastleSkillbox.Code.Infrastructure.Services.UIFactory;
using UnityEngine;
using Zenject;

namespace SkyCastleSkillbox.Code.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPayloadedState<string>, IPayloadedState<SceneID>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly ISceneContextService _sceneContext;
        private readonly IUIFactory _uiFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataService staticDataService, ISceneContextService sceneContext, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _sceneContext = sceneContext;
            _uiFactory = uiFactory;
            _uiFactory = uiFactory;
            _sceneContext = sceneContext;
            _staticDataService = staticDataService;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(SceneID levelID)
        {
            _sceneLoader.LoadScene(levelID, OnLoaded);
        }

        public void Enter(string levelID)
        {
#if !UNITY_EDITOR
            _sceneLoader.LoadScene(scene, OnLoaded);
#endif
#if UNITY_EDITOR
            OnLoaded();
#endif
        }

        private void OnLoaded()
        {
            Debug.Log(_sceneContext.PlayerSpawnPoint);
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }
    }
}