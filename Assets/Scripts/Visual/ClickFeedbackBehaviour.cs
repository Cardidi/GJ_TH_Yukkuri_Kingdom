using System;
using Environment.Pool;
using UnityEngine;

namespace Visual
{
    public class ClickFeedbackBehaviour : PoolMonoBehaviour
    {
        public Animation Animation;

        public override void OnInstanced(PoolRoot pool)
        {
            base.OnInstanced(pool);
            gameObject.SetActive(false);
        }

        public override void OnUsed()
        {
            base.OnUsed();
            gameObject.SetActive(true);
            Animation.Play();
        }

        private void Update()
        {
            if (!Animation.isPlaying)
                FreeSelf();
        }

        public override void OnFree()
        {
            base.OnFree();
            gameObject.SetActive(false);
        }
    }
}