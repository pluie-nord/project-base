using SkyCastleSkillbox.Code.Infrastructure.Saving;

namespace SkyCastleSkillbox.Code.Infrastructure.Services.SaveLoadService
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