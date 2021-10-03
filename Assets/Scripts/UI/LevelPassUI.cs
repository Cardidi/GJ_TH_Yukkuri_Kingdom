using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelPassUI : MonoBehaviour
    {
        public Button Retry, Next, Exit;
        public GameObject UIRoot;

        private string NextLevelPath;

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
            
            Next.onClick.AddListener(() =>
            {
                var manager = LevelManager.GetManager();
                manager.LoadingUI.OpenScene(NextLevelPath);
                Hide();
            });
            
            Exit.onClick.AddListener(() =>
            {
                var manager = LevelManager.GetManager();
                manager.LoadingUI.ReturnTitle();
                Hide();
            });
        }

        public void Open(string nextLevelPath)
        {
            NextLevelPath = nextLevelPath;
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