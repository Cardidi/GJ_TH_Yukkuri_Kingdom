using System;
using UnityEngine;

namespace PlayModule
{
    public class HiddenObjects : MonoBehaviour
    {
        public ButtonSets ButtonSets;
        public bool HideWhileButtonValid;
        public GameObject[] HiddenTargets;

        private void Update()
        {
            foreach (var Target in HiddenTargets)
            {
                if(ButtonSets.Triggered)
                    Target.SetActive(!HideWhileButtonValid);
                else
                    Target.SetActive(HideWhileButtonValid);
                
            }
        }
    }
}