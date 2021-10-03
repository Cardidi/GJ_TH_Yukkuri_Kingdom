using System;

namespace PlayModule
{
    public class ButtonANDMerge : ButtonSets
    {
        public ButtonSets[] ButtonSets;

        private void LateUpdate()
        {
            Triggered = true;

            foreach (var set in ButtonSets)
            {
                if (!set.Triggered)
                {
                    Triggered = false;
                    return;
                }
            }
        }
    }
}