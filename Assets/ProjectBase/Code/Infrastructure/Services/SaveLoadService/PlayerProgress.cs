using ProjectBase.Code.Infrastructure.Saving;

namespace ProjectBase.Code.Infrastructure.Services.SaveLoadService
{
    public class PlayerProgress
    {
        public PlayerSettings PlayerSettings;
        
        public PlayerProgress()
        {
            PlayerSettings = new PlayerSettings();
        }
    }
}