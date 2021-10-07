using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonTargetHit : ButtonSets
    {
        public GameObject TargetObject;
        public GameObject ValidOnlyThisObjectEnabled;

        private void Awake()
        {
            Triggered = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnTriggerEnter2D(other.collider);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            OnTriggerEnter2D(other.collider);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerEnter2D(other);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Triggered) return;
            if (other.gameObject == TargetObject)
            {
                if (ValidOnlyThisObjectEnabled != null)
                {
                    Triggered = ValidOnlyThisObjectEnabled.activeSelf;
                    return;
                }
                Triggered = true;
            }
        }
    }
}