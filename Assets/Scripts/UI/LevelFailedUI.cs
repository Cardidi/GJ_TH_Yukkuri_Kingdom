using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelFailedUI : MonoBehaviour
    {
        
        public Button Retry, Exit;
        public GameObject UIRoot;
        
        private void Awake()
        {
            Retry.onClick.AddListener(() =>
            {
                if (LevelManager.GetManager().TryGetProfile(out var profile))
                {
                    LevelManager.GetManager().LoadingUI.OpenScene(profile.gameObject.scene.path);
                    Hide();
                }
                else
                {
                    throw new Exception();
                }
            });

            
            Exit.onClick.AddListener(() =>
            {
                var manager = LevelManager.GetManager();
                manager.LoadingUI.ReturnTitle();
                Hide();
            });
        }

        public void Open()
        {
            gameObject.SetActive(true);
            UIRoot.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            UIRoot.SetActive(false);
        }
    }
}