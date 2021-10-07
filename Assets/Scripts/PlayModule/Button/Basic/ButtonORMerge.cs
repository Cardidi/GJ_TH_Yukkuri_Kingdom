using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonORMerge : ButtonSets
    {
        public ButtonSets[] ButtonSets;

        private void LateUpdate()
        {
            Triggered = false;
            
            if (ButtonSets.Length == 0) return;
            foreach (var field in ButtonSets)
            {
                if (field.Triggered)
                {
                    Triggered = true;
                    return;
                }
            }
        }
    }
}