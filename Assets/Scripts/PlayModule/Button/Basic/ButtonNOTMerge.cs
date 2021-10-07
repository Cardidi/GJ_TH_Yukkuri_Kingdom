using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonNOTMerge : ButtonSets
    {
        public ButtonSets ButtonSets;
        public bool DefaultValueIfNull = false;

        private void LateUpdate()
        {
            if (ButtonSets != null)
                Triggered = !ButtonSets.Triggered;
            else
                Triggered = DefaultValueIfNull;
        }
    }
}