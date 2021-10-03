using System;
using UnityEngine;

namespace Player
{
    public class BallBlocker : MonoBehaviour
    {
        private LevelManager mManager;
        private BallController mController;

        private void Start()
        {
            mManager = LevelManager.GetManager();
            if (mManager.TryGetProfile(out var profile))
            {
                mController = profile.Ball;
            }
            else
            {
                throw new Exception("Did not have an profile!");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (mManager == null) Start();
            
            if (other.gameObject.Equals(mController.gameObject))
            {
                mController.CleanDirectionTargets();
            }
        }
    }
}