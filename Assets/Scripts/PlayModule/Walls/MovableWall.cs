using System;
using Player;
using UnityEngine;

namespace PlayModule
{
    public class MovableWall : MonoBehaviour
    {
        public Animator Animator;
        public BallSeeker Seeker;
        public SpriteRenderer Render;
        public Color FreezeColor = Color.cyan;
        public bool IsMoving { get; private set; }

        private void Start()
        {
            Seeker.enabled = false;
            Animator.speed = 1;
            IsMoving = true;
        }

        private void OnMouseDown()
        {
            Animator.speed = 0;
            Seeker.enabled = true;
            IsMoving = false;
            Render.color = FreezeColor;
        }
    }
}