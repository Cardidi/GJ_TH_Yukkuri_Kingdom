using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class BallController : MonoBehaviour
    {
        public Rigidbody2D Rigidbody2D;
        public Animator Animator;
        public SpriteRenderer Renderer;
        public TrailRenderer Trail1, Trail2;
        public AudioSource AudioSource;
        
        public float MoveAnimatorChangeValue = 0.2f;
        public float HitAnimatorChangeVelocity = 1f;
        public float Speed = 10;
        public int PointLimit = 2;
        public string[] CollideAnimationTags;
        
        public AudioClip[] CollideAudioClip;

        private LevelManager mManager;
        private bool mUsingTrail1 = true;
        private bool mCanHit = true;
        private bool mCanMove = true;
        
        private List<Vector2> Directions = new List<Vector2>();

        private void OnEnable()
        {
            SwitchTrail();
        }

        private void FixedUpdate()
        {
            if (mCanMove && Directions.Count != 0)
            {
                foreach (var d in Directions)
                {
                    Rigidbody2D.AddForce(d * Speed);
                }
            }
        }

        private void Update()
        {
            var usedTrail = mUsingTrail1 ? Trail1 : Trail2;
            usedTrail.transform.position = Rigidbody2D.transform.position;
            
            Animator.SetBool("Move", Rigidbody2D.velocity.magnitude >= MoveAnimatorChangeValue);
            var velocityX = Rigidbody2D.velocity.x;
            
            if (velocityX < -MoveAnimatorChangeValue)
                Renderer.flipX = false;
            
            if (velocityX > MoveAnimatorChangeValue)
                Renderer.flipX = true;
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (mCanHit && Rigidbody2D.velocity.magnitude > HitAnimatorChangeVelocity)
            {
                foreach (var Tag in CollideAnimationTags)
                {
                    if (other.gameObject.CompareTag(Tag))
                    {
                        StartCoroutine(HitReset(0.5f));
                        Animator.SetTrigger("Hit");
                        if (CollideAudioClip.Length != 0)
                        {
                            if (CollideAudioClip.Length == 1)
                            {
                                AudioSource.clip = CollideAudioClip[0];
                                AudioSource.Play();
                            }
                            else
                            {
                                AudioSource.clip = CollideAudioClip[Random.Range(0, CollideAudioClip.Length)];
                                AudioSource.Play();
                            }
                            return;
                        }
                    }
                }
            }
        }

        private IEnumerator HitReset(float waitSec)
        {
            mCanHit = false;
            yield return new WaitForSeconds(waitSec);

            mCanHit = true;
        }
        
        public void SwitchTrail()
        {
            StartCoroutine(SwitchTrailEnu());
        }
        
        private IEnumerator SwitchTrailEnu()
        {
            Trail1.emitting = false;
            Trail2.emitting = false;
            yield return null;
            
            if (mUsingTrail1)
            {
                Trail2.emitting = true;
                mUsingTrail1 = false;
            }
            else
            {
                Trail1.emitting = true;
                mUsingTrail1 = true;
            }
        }

        public void SetMovable(bool move)
        {
            mCanMove = move;
        }

        public bool AddDirectionTarget(Vector3 vec)
        {
            if (Directions.Count >= PointLimit) return false;
            
            var delta = vec - transform.position;
            Directions.Add(delta.normalized);
            return true;
        }

        public void CleanDirectionTargets()
        {
            Directions.Clear();
        }
    }
}