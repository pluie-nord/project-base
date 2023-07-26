using ProjectBase.Code.Infrastructure.StaticData;

namespace ProjectBase.Code.Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        void Load();
        GameStaticData GetGameStaticData();
    }
}