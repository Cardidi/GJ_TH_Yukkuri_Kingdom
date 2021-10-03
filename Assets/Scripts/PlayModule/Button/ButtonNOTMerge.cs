using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonNOTMerge : ButtonSets
    {
        public ButtonSets ButtonSets;

        private void LateUpdate()
        {
            if (ButtonSets != null)
                Triggered = !ButtonSets.Triggered;
            else
                Triggered = false;
        }
    }
}