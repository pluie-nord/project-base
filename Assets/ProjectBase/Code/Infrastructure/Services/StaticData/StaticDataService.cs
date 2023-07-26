using System.Collections.Generic;
using ProjectBase.Code.Infrastructure.Data;
using ProjectBase.Code.Infrastructure.Services.AssetProvider;
using ProjectBase.Code.Infrastructure.StaticData;

namespace ProjectBase.Code.Infrastructure.Services.StaticData
{
    /// <summary>
    /// Provide static data (balance or other GD parameters) for services and other entities
    /// </summary>
    public class StaticDataService : IStaticDataService
    {
        private readonly Dictionary<WindowID, WindowConfig> _windows = new();

        private readonly IAssetProvider _assetProvider;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameStaticData Data { get; private set; }

        public void Load()
        {
            _assetProvider.Load();
            Data = _assetProvider.GetGameStaticData();
            LoadWindows();
        }

        public WindowConfig GetWindow(WindowID id)
        {
            return _windows.TryGetValue(id, out var windowConfig) ? windowConfig : null;
        }

        private void LoadWindows()
        {
            foreach (var window in Data.Windows)
                _windows.Add(window.ID, window);
        }
    }
}