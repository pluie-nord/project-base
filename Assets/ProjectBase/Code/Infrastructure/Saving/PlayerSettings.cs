using System;
using UnityEngine;

namespace SkyCastleSkillbox.Code.Infrastructure.Saving
{
    [Serializable]
    public class PlayerSettings
    {
        [SerializeField] public float soundVolume;
        [SerializeField] public float musicVolume;
        [SerializeField] public bool soundOn;
        [SerializeField] public bool musicOn;

        public PlayerSettings()
        {
            soundVolume = 1;
            musicVolume = 1;
            soundOn = true;
            musicOn = true;
        }
    }
}