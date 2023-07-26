using System;
using ProjectBase.Code.Infrastructure.Data;

namespace ProjectBase.Code.Infrastructure.Services.SceneLoaderService
{
    public interface ISceneLoader
    {
        void LoadScene(string sceneName, Action onLoaded = null);
        void LoadScene(SceneID sceneID, Action onLoaded = null);
    }
}