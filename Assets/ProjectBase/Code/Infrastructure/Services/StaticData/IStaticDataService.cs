using ProjectBase.Code.Infrastructure.Data;
using ProjectBase.Code.Infrastructure.StaticData;

namespace ProjectBase.Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        GameStaticData Data { get; }
        void Load();
        WindowConfig GetWindow(WindowID id);
    }
}