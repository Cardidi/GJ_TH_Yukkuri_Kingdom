using System;
using UnityEngine;
using Visual;

namespace Player
{
    public class BallSeeker : MonoBehaviour
    {
        private LevelManager mManager;
        private BallController mController;
        private Camera mCamera;
        private ClickFeedbackController mFeedbackController;
        
        private void Start()
        {
            mManager = LevelManager.GetManager();
            if (mManager.TryGetProfile(out var profile))
            {
                mController = profile.Ball;
                mCamera = profile.Camera;
                mFeedbackController = profile.ClickFeedback;
            }
            else
            {
                throw new Exception("Did not have an profile!");
            }
        }

        private void OnMouseDown()
        {
            if (mManager == null) Start();
            
            var pos = mCamera.ScreenToWorldPoint(Input.mousePosition);
            mFeedbackController.DoClick(pos, mController.AddDirectionTarget(pos));
        }
    }
}