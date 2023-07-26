using ProjectBase.Code.Infrastructure.Data;
using ProjectBase.Code.Infrastructure.Services.StaticData;
using ProjectBase.Code.Infrastructure.Services.ZenjectFactory;
using ProjectBase.Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace ProjectBase.Code.Infrastructure.Services.UIFactory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;
        private readonly IStaticDataService _staticDataService;
        private readonly IZenjectFactory _zenjectFactory;

        [Inject]
        public UIFactory(IStaticDataService staticDataService, IZenjectFactory zenjectFactory)
        {
            _zenjectFactory = zenjectFactory;
            _staticDataService = staticDataService;
        }
        
        public void CreateUiRoot()
        {
            if (_uiRoot != null)
                Object.Destroy(_uiRoot.gameObject);
            WindowConfig config = _staticDataService.GetWindow(WindowID.UiRoot);
            GameObject uiRoot = _zenjectFactory.Instantiate(config.Window.gameObject);
            _uiRoot = uiRoot.transform;
        }

        public void ClearUIRoot()
        {
            for (int i = 0; i < _uiRoot.childCount; i++) 
                Object.Destroy(_uiRoot.GetChild(i).gameObject);
        }
    }
}