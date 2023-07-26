using SkyCastleSkillbox.Code.StaticData;
using UnityEngine;

namespace SkyCastleSkillbox.Code.Infrastructure.StaticData
{
    [CreateAssetMenu(fileName = "GameStaticData", menuName = "Static Data/GameStaticData")]
    public class GameStaticData : ScriptableObject
    {
        [SerializeField] private WindowStaticData _windowStaticData;

        public WindowConfig[] Windows => _windowStaticData.Windows;
    }
}