using System;
using System.Collections;
using UnityEngine;

namespace PlayModule.LevelSenders
{
    public class Send2Level : MonoBehaviour
    {
        public ButtonSets ListeningButtonSet;
        public bool TrueToOpen = true;
        public float OpenDelay = 0f;
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
            StartCoroutine(OpenCount());
        }

        private IEnumerator OpenCount()
        {
            if (OpenDelay > 0)
                yield return new WaitForSeconds(OpenDelay);
            
            LevelManager.GetManager().LoadingUI.OpenScene(TargetLevelPath);
        }
    }
}