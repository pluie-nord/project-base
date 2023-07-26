using CrushLink.Code.Infrastructure.Services.UpdateBehaviorService;
using ProjectBase.Code.Infrastructure.Services.AssetProvider;
using ProjectBase.Code.Infrastructure.Services.CoroutineRunner;
using ProjectBase.Code.Infrastructure.Services.SaveLoadService;
using ProjectBase.Code.Infrastructure.Services.SceneContext;
using ProjectBase.Code.Infrastructure.Services.SceneLoaderService;
using ProjectBase.Code.Infrastructure.Services.SoundService;
using ProjectBase.Code.Infrastructure.Services.StaticData;
using ProjectBase.Code.Infrastructure.Services.UIFactory;
using ProjectBase.Code.Infrastructure.Services.ZenjectFactory;
using ProjectBase.Code.Infrastructure.StateMachine;
using ProjectBase.Code.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace ProjectBase.Code.Infrastructure.DI.Installers
{
    public class ProjectContextInstaller : MonoInstaller, ICoroutineRunner
    {
        [SerializeField] private UpdateBehaviour _updateBehaviour;
        [SerializeField] private SoundService _soundService;
        
        public override void InstallBindings()
        {
            BindServices();
            BindFactories();
            BindGameStateMachine();
        }

        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneContextService>().To<SceneContextService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
            Container.Bind<IUpdateBehaviourService>().FromInstance(_updateBehaviour).AsSingle();
            Container.Bind<ISoundService>().FromInstance(_soundService).AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().To<BootstrapState>().AsSingle();
            Container.Bind<LoadMainMenuState>().To<LoadMainMenuState>().AsSingle();
            Container.Bind<LoadLevelState>().To<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().To<GameLoopState>().AsSingle();
        }

        private void BindFactories()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IZenjectFactory>().To<ZenjectFactory>().AsSingle();
        }
    }
}