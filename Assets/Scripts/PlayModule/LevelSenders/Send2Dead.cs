using System.Collections;
using UnityEngine;

namespace PlayModule.LevelSenders
{
    public class Send2Dead : MonoBehaviour
    {
        public ButtonSets ListeningButtonSet;
        public bool TrueToOpen = true;

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
            LevelManager.GetManager().FailedUI.Open();
        }
        
    }
}