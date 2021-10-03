using System;
using System.Collections;
using Player;
using UnityEngine;

namespace PlayModule
{
    public class BallTransport : MonoBehaviour
    {
        public BallTransport TargetTransport;
        public BallTransportWall LeftWall, RightWall;
        public string[] TagsFilter = {"Player"};
        public SpriteRenderer Renderer;
        public Sprite OpenSprite, CloseSprite;

        [Header("Button Settings")] 
        public bool ControlByButton = false;
        public ButtonSets SelectButtonSets;
        public bool OpenWhileButtonValid;

        private void Update()
        {
            if (ControlByButton)
            {
                if (SelectButtonSets.Triggered)
                {
                    LeftWall.gameObject.SetActive(OpenWhileButtonValid);
                    RightWall.gameObject.SetActive(OpenWhileButtonValid);

                    if (Renderer != null)
                    {
                        Renderer.sprite = OpenWhileButtonValid ? OpenSprite : CloseSprite;
                    }
                }
                else
                {
                    LeftWall.gameObject.SetActive(!OpenWhileButtonValid);
                    RightWall.gameObject.SetActive(!OpenWhileButtonValid);
                    
                    if (Renderer != null)
                    {
                        Renderer.sprite = !OpenWhileButtonValid ? OpenSprite : CloseSprite;
                    }
                }
            }
            else
            {
                LeftWall.gameObject.SetActive(true);
                RightWall.gameObject.SetActive(true);
                if (Renderer != null)
                {
                    Renderer.sprite = OpenSprite;
                }
            }
        }
        
        public void OnBallTransit(GameObject obj, Vector3 ballOffset, bool isRight)
        {
            ballOffset.x = -ballOffset.x;
            var wallCenterPoint = isRight ? LeftWall.transform.position : RightWall.transform.position;
            var ballCenterPoint = ballOffset + wallCenterPoint;
            
            if (obj.TryGetComponent<BallController>(out var Controller))
            {
                
                Controller.SwitchTrail();
                Controller.CleanDirectionTargets();
            }
            
            if (obj.TryGetComponent<Rigidbody2D>(out var rb))
            {
                rb.position = ballCenterPoint;
            }

            StartCoroutine(SkipTransition(0.5f));
            StartCoroutine((SkipVelocity(obj)));
        }

        public bool IsTransitTarget(GameObject other)
        {
            foreach (var tag in TagsFilter)
            {
                if (other.CompareTag(tag))
                    return true;
            }

            return false;
        }
        

        private IEnumerator SkipTransition(float sec)
        {
            LeftWall.CheckBall = false;
            RightWall.CheckBall = false;
            yield return new WaitForSeconds(sec);
            
            LeftWall.CheckBall = true;
            RightWall.CheckBall = true;
        }

        private IEnumerator SkipVelocity(GameObject obj)
        {
            if (obj.TryGetComponent<Rigidbody2D>(out var rb))
            {
                
                var velocity = rb.velocity;
                yield return null;

                rb.velocity = velocity;
            }

            yield return null;
        }
        

    }
}