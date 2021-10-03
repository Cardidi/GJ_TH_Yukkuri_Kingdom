using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PlayModule.Dialog
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField]
        protected Text NameField;
        [SerializeField] 
        protected Text DialogField;
        [SerializeField] 
        protected Image LeftIcon;
        [SerializeField] 
        protected Image RightIcon;
        [SerializeField] 
        protected GameObject NextLineSign;

        public GameObject RootObject;

        public float NextLineWaitTime = 1.5f;
        
        public bool CanNextLine { get; private set; }

        public event Action<DialogView> OnNextLineCalled;

        public void Show()
        {
            RootObject.SetActive(true);
            CanNextLine = true;
        }

        public void Hide()
        {
            RootObject.SetActive(false);
            CanNextLine = false;
        }
        
        public void SetDialog(Sprite leftIcon, Sprite rightIcon, string Name, string Dialog)
        {
            LeftIcon.sprite = leftIcon;
            RightIcon.sprite = rightIcon;
            NameField.text = Name;
            DialogField.text = Dialog;
            StartCoroutine(NextLineEnum(NextLineWaitTime));
        }

        private IEnumerator NextLineEnum(float waitSec)
        {
            CanNextLine = false;
            NextLineSign.SetActive(false);

            yield return new WaitForSeconds(waitSec);
            CanNextLine = true;
            NextLineSign.SetActive(true);
        }

        private void OnMouseDown()
        {
            if (CanNextLine)
                OnNextLineCalled?.Invoke(this);
        }
    }
}