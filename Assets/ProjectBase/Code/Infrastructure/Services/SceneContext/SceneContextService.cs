using UnityEngine;

namespace ProjectBase.Code.Infrastructure.Services.SceneContext
{
    public class SceneContextService : ISceneContextService
    {
        private Transform _playerSpawnPoint;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;

        public void SetPlayerSpawnPoint(Transform playerSpawnPoint)
        {
            _playerSpawnPoint = playerSpawnPoint;
        }
    }
}