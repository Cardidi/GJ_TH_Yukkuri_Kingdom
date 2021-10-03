using System;
using UnityEngine;

namespace PlayModule
{
    public class BallTransportWall : MonoBehaviour
    {
        public BallTransport Transport;
        public bool CheckBall = true;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnTriggerEnter2D(other.collider);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (CheckBall && Transport.IsTransitTarget(other.gameObject))
            {
                var offset = other.transform.position - transform.position;
                Transport.TargetTransport.OnBallTransit(other.gameObject, offset, Transport.RightWall == this);
            }
        }
    }
}