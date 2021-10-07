using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonTargetHold : ButtonSets
    {
        public GameObject TargetObject;

        private void Awake()
        {
            Triggered = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == TargetObject)
            {
                Triggered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject == TargetObject)
            {
                Triggered = false;
            }
        }
    }
}