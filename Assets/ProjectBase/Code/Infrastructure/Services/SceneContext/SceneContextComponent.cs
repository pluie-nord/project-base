using UnityEngine;
using Zenject;

namespace ProjectBase.Code.Infrastructure.Services.SceneContext
{
    public class SceneContextComponent : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;

        private ISceneContextService _sceneContextService;

        [Inject]
        private void Construct(ISceneContextService sceneContextService)
        {
            _sceneContextService = sceneContextService;
        }

        private void Awake()
        {
            InitSceneContext();
        }

        private void InitSceneContext()
        {
            _sceneContextService.SetPlayerSpawnPoint(_playerSpawnPoint);
        }
    }
}