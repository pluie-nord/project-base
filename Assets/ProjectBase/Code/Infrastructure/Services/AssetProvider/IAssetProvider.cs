using SkyCastleSkillbox.Code.Infrastructure.StaticData;

namespace SkyCastleSkillbox.Code.Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        void Load();
        GameStaticData GetGameStaticData();
    }
}