using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class TouchUIEvent : MonoBehaviour
    {
        public float HoldingTime = 1.5f;
        private LevelManager mManager;
        private Coroutine mC;
        
        private void Awake()
        {
            mManager = LevelManager.GetManager();
        }

        private void OnMouseDown()
        {
            if (!mManager.CanInput())
            {
                return;
            }

            if (mC != null)
            {
                StopCoroutine(mC);
                mC = null;
            }
            mC = StartCoroutine(HoldChecker());
        }

        private void OnMouseUp()
        {
            if (mC != null)
            {
                StopCoroutine(mC);
                mC = null;
            }
        }

        private IEnumerator HoldChecker()
        {
            yield return new WaitForSeconds(HoldingTime);
            
            mManager.HoldingUI.OpenIt();
        }
        
    }
}