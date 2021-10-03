using System;
using UnityEngine;

namespace PlayModule
{
    public class ButtonTargetHit : ButtonSets
    {
        public GameObject TargetObject;

        private void Awake()
        {
            Triggered = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnTriggerEnter2D(other.collider);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == TargetObject)
            {
                Triggered = true;
            }
        }
    }
}