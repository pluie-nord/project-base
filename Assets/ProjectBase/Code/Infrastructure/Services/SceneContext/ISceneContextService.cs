using UnityEngine;

namespace ProjectBase.Code.Infrastructure.Services.SceneContext
{
    public interface ISceneContextService
    {
        Transform PlayerSpawnPoint { get; }

        void SetPlayerSpawnPoint(Transform playerSpawnPoint);
    }
}