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