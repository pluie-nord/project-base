using ProjectBase.Code.Infrastructure.Data;
using ProjectBase.Code.Infrastructure.Services.SaveLoadService;
using ProjectBase.Code.Infrastructure.Services.StaticData;
using ProjectBase.Code.Infrastructure.Services.UIFactory;
using UnityEngine.SceneManagement;
using Zenject;

namespace ProjectBase.Code.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IUIFactory _uiFactory;
        private readonly IStaticDataService _staticDataService;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public BootstrapState(IPersistentProgressService progressService,
            ISaveLoadService saveLoadService, IUIFactory uiFactory, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        public void SetupStateMachine(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            LoadServiceData();
            OnLoaded();
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
            _saveLoadService.SaveProgress();
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();
            return progress;
        }

        private void LoadServiceData()
        {
            _staticDataService.Load();
            _uiFactory.CreateUiRoot();
        }

        private void OnLoaded()
        {
            //Editor stuff, needed to have ability to start playmode at any scene, not only from bootstrap scene
#if UNITY_EDITOR
            if (SceneManager.GetActiveScene().name == SceneID.BootstrapScene.ToString())
                _gameStateMachine.Enter<LoadMainMenuState>();
            else if (SceneManager.GetActiveScene().name == SceneID.MainMenuScene.ToString())
                _gameStateMachine.Enter<LoadMainMenuState, bool>(true);
            else
                _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
#else
  _gameStateMachine.Enter<LoadMainMenuState>();
#endif
        }

        public void Exit()
        {
        }
    }
}