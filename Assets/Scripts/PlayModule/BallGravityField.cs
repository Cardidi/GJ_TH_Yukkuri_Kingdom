using System;
using Player;
using UnityEngine;

namespace PlayModule
{
    public class BallGravityField : MonoBehaviour
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
        }

        private void CalcForce()
        {
            var velocity = mController.Rigidbody2D.velocity;
            var delta = transform.position - mController.gameObject.transform.position;
            var mass = mController.Rigidbody2D.mass;
            
            
        }
    }
}