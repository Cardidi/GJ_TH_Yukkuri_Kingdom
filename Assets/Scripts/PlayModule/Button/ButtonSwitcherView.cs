using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayModule
{
    public class ButtonSwitcherView : MonoBehaviour
    {
        public ButtonSets ListenButtonSet;
        public SpriteRenderer Renderer;
        public Sprite ReleaseSprite, PressSprite;
        
        private void Update()
        {
            if (Renderer != null)
            {
                Renderer.sprite = ListenButtonSet.Triggered ? PressSprite : ReleaseSprite;
            }
        }

    }
}