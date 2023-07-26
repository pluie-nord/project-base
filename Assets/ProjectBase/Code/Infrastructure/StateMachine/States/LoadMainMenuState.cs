using SkyCastleSkillbox.Code.Infrastructure.Data;
using SkyCastleSkillbox.Code.Infrastructure.Services.SceneLoaderService;
using SkyCastleSkillbox.Code.Infrastructure.Services.UIFactory;
using Zenject;

namespace SkyCastleSkillbox.Code.Infrastructure.StateMachine.States
{
    public class LoadMainMenuState : IState, IPayloadedState<bool>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public LoadMainMenuState(ISceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _sceneLoader = sceneLoader;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter(bool payload)
        {
#if !UNITY_EDITOR
             _sceneLoader.LoadScene(SceneID.MainMenuScene, OnLoaded);
#endif
#if UNITY_EDITOR
            OnLoaded();
#endif
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneID.MainMenuScene, OnLoaded);
        }

        private void OnLoaded()
        {
        }

        public void Exit()
        {
            _uiFactory.ClearUIRoot();
        }
    }
}