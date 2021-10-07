using System;
using UnityEngine;

namespace PlayModule.LevelSenders
{
    public class Send2Pass : MonoBehaviour
    {
        public ButtonSets ListeningButtonSet;
        public bool TrueToOpen = true;
        public string TargetLevelPath;

        private bool mIsTriggred;

        private void OnEnable()
        {
            mIsTriggred = false;
        }

        private void Update()
        {
            if (mIsTriggred || ListeningButtonSet == null)
                return;
            
            if (TrueToOpen)
            {
                if (ListeningButtonSet.Triggered)
                {
                    Open();
                    mIsTriggred = true;
                }
            }
            else
            {
                if (!ListeningButtonSet.Triggered)
                {
                    Open();
                    mIsTriggred = true;
                }
            }

        }

        private void Open()
        {
            if (!string.IsNullOrEmpty(TargetLevelPath.Trim()))
            {
                LevelManager.GetManager().PassUI.Open(TargetLevelPath);
                return;
            }
            else
            {
                if (LevelManager.GetManager().TryGetProfile(out var profile))
                {
                    if (!string.IsNullOrEmpty(profile.DefaultNextLevelPath.Trim()))
                    {
                        LevelManager.GetManager().PassUI.Open(profile.DefaultNextLevelPath);
                        return;
                    }
                }
            }
            
            Debug.LogWarning("You don't have a scene target!");
        }
    }
}