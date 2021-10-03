using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadingUIChaser : MonoBehaviour
    {
        public GameObject Root;
        public float WaitSeconds = 4f;
        public string TitlePath;

        private string path;

        public void ReturnTitle()
        {
            OpenScene(TitlePath);
        }
        
        public void OpenScene(string scenePath)
        {
            Time.timeScale = 1;
            gameObject.SetActive(true);
            Root.SetActive(true);
            
            if (LevelManager.GetManager().TryGetProfile(out var profile))
            {
                profile.CloseLevel();
            }

            path = scenePath;
            StartCoroutine(WaitForUICompete(WaitSeconds));
        }

        private IEnumerator WaitForUICompete(float waitSec)
        {
            yield return new WaitForSeconds(waitSec);
            var task = SceneManager.LoadSceneAsync(path);
            task.completed += operation =>
            {
                gameObject.SetActive(false);
                Root.SetActive(false);
            };
        }
    }
}