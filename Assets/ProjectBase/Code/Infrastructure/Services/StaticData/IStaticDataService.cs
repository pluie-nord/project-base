using SkyCastleSkillbox.Code.Infrastructure.Data;
using SkyCastleSkillbox.Code.Infrastructure.StaticData;

namespace SkyCastleSkillbox.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        GameStaticData Data { get; }
        void Load();
        WindowConfig GetWindow(WindowID id);
    }
}