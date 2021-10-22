using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HoldingUI : MonoBehaviour
    {
        public bool Opened;
        public GameObject Root;
        public AudioSource AudioSource;
        public Button Return, Retry, Exit, Next;

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
                mManager.LoadingUI.ReturnTitle();
                Opened = !Opened;
            });
            
            Next.onClick.AddListener(() =>
            {
                if (mManager.TryGetProfile(out var profile))
                {
                    mManager.LoadingUI.OpenScene(profile.DefaultNextLevelPath);
                    Opened = !Opened;
                }
            });

            Opened = false;
        }

        public void OpenIt()
        {
            if (mManager.CanInput()) Opened = !Opened;
        }

        private void Update()
        {
            if (mManager.GameProfile)
            {
                var last = Opened;
                if (mManager.CanInput() && Input.GetKeyDown(KeyCode.Escape)) Opened = !Opened;
                
                Root.SetActive(Opened);
                Time.timeScale = Opened ? 0 : 1;

                if (Opened && !last) AudioSource.Play();

                if (mManager.TryGetProfile(out var profile) && !string.IsNullOrEmpty(profile.DefaultNextLevelPath))
                {
                    Next.gameObject.SetActive(true);
                }
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