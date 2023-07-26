using UnityEngine;
using UnityEngine.UI;

namespace SkyCastleSkillbox.Code.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        public Button CloseButton;
    
        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            if (CloseButton != null)
                CloseButton.onClick.AddListener(CloseWindow);
        }

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
            LoadStartupData();
        }

        protected virtual void Initialize()
        {
        }

        protected virtual void SubscribeUpdates()
        {
        }

        protected virtual void LoadStartupData()
        {
        }

        protected virtual void CloseWindow()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        protected virtual void Cleanup()
        {
            
        }
    }
}
