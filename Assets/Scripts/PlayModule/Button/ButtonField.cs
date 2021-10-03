using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayModule
{
    public class ButtonField : ButtonSets
    {
        public string[] TagFilters;
        public SpriteRenderer Renderer;
        public Sprite ReleaseSprite, PressSprite;
        private Coroutine mCoroutine;

        private List<GameObject> mStayedObj = new List<GameObject>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnTriggerStay2D(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            OnTriggerExit2D(other.collider);
        }

        private void Update()
        {
            if (Renderer != null)
            {
                Renderer.sprite = Triggered ? PressSprite : ReleaseSprite;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            foreach (var tag in TagFilters)
            {
                if (other.gameObject.CompareTag(tag))
                    mStayedObj.Remove(other.gameObject);
            }
            
            Triggered = mStayedObj.Count > 0;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            foreach (var tag in TagFilters)
            {
                if (other.gameObject.CompareTag(tag) && !mStayedObj.Contains(other.gameObject))
                    mStayedObj.Add(other.gameObject);
            }
            
            Triggered = mStayedObj.Count > 0;
        }
    }
}