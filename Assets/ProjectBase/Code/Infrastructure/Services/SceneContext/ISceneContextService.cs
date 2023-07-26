using UnityEngine;

namespace SkyCastleSkillbox.Code.Infrastructure.Services.SceneContext
{
    public interface ISceneContextService
    {
        Transform PlayerSpawnPoint { get; }

        void SetPlayerSpawnPoint(Transform playerSpawnPoint);
    }
}