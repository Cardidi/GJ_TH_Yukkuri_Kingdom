using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HoldingUI : MonoBehaviour
    {
        public bool Opened;
        public GameObject Root;
        public Button Return, Retry, Exit;

        private LevelManager mManager;

        private void Awake()
        {
            mManager = LevelManager.GetManager();
            
            Return.onClick.AddListener(() =>
            {
                Opened = !Opened;
            });
            
            Retry.onClick.AddListener(() =>
            {
                if (LevelManager.GetManager().TryGetProfile(out var profile))
                {
                    LevelManager.GetManager().LoadingUI.OpenScene(profile.gameObject.scene.path);
                    Opened = !Opened;
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
                Opened = !Opened;
            });
        }

        private void Update()
        {
            if (mManager.GameProfile)
            {
                if (Input.GetKeyDown(KeyCode.Escape)) Opened = !Opened;
                
                Root.SetActive(Opened);
                Time.timeScale = Opened ? 0 : 1;
            }
            else
            {
                Root.SetActive(false);
                Time.timeScale = 1;
            }
        }

        public void DoReset()
        {
            Opened = false;
        }
    }
}