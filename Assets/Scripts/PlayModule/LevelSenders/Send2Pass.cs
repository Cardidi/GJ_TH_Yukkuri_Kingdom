using UnityEngine;

namespace PlayModule.LevelSenders
{
    public class Send2Pass : MonoBehaviour
    {
        public ButtonSets ListeningButtonSet;
        public bool TrueToOpen = true;
        public string TargetLevelPath;
        
        private void Update()
        {
            if (ListeningButtonSet != null && TrueToOpen)
            {
                if (ListeningButtonSet.Triggered) Open();
            }
            else
            {
                if (ListeningButtonSet.Triggered) Open();
            }
        }

        private void Open()
        {
            LevelManager.GetManager().PassUI.Open(TargetLevelPath);
        }
    }
}