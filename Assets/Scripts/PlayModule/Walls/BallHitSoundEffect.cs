using System;
using UnityEngine;

namespace PlayModule
{
    [RequireComponent(typeof(AudioSource))]
    public class BallHitSoundEffect : MonoBehaviour
    {
        public AudioSource AudioSource;
        public ButtonSets ListenButtonSet;

        private bool mIsPlayed;

        private void Awake()
        {
            mIsPlayed = false;
        }

        private void Update()
        {
            if (ListenButtonSet != null && ListenButtonSet.Triggered && !mIsPlayed)
            {
                AudioSource.loop = false;
                AudioSource.Play();

                mIsPlayed = true;
            }
        }
    }
}