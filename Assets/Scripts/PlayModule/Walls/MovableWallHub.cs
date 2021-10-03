using System;
using Player;
using UnityEngine;

namespace PlayModule
{
    public class MovableWallHub : MonoBehaviour
    {
        public MovableWall[] Walls;
        private BallController mController;

        private void Start()
        {
            if (LevelManager.GetManager().TryGetProfile(out var profile))
            {
                mController = profile.Ball;
                mController.SetMovable(false);
            }
        }

        private void Update()
        {
            int running = 0;
            foreach (var wall in Walls)
            {
                if (wall.IsMoving) running++;
            }

            if (running == 0)
            {
                enabled = false;
                mController.SetMovable(true);
                mController.CleanDirectionTargets();
            }
        }
    }
}