using System;
using SkyCastleSkillbox.Code.Infrastructure.Data;

namespace SkyCastleSkillbox.Code.Infrastructure.Services.SceneLoaderService
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoaded = null);
        void LoadScene(SceneID sceneID, Action onLoaded = null);
    }
}