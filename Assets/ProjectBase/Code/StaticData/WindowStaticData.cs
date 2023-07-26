using SkyCastleSkillbox.Code.Infrastructure.StaticData;
using UnityEngine;

namespace SkyCastleSkillbox.Code.StaticData
{
    [CreateAssetMenu(menuName = nameof(WindowStaticData), fileName = nameof(WindowStaticData), order = 0)]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private WindowConfig[] _windows;

        public WindowConfig[] Windows => _windows;
    }
}