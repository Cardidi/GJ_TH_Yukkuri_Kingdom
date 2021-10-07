using System;
using System.Collections;
using UnityEngine;

namespace PlayModule
{
    public class ExitButton : MonoBehaviour
    {
        public ButtonSets ListenButtonSet;
        public float Delay;
        private bool T = false;

        private void Update()
        {
            if (!T && ListenButtonSet.Triggered)
            {
                StartCoroutine(WaitToClose());
                T = true;
            }
        }

        private IEnumerator WaitToClose()
        {
            yield return new WaitForSeconds(Delay);
            
            Application.Quit();
        }
    }
}