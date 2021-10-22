using System;
using PlayModule.Dialog;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Init
{
    public class AppInit : MonoBehaviour
    {
        public GameObject DialogUI;
        public GameObject LoadingUI;
        public GameObject LevelPassUI;
        public GameObject LevelFailedUI;
        public GameObject HoldingUI;
        public GameObject CoverageUI;
        
        
        public string InitScenePath;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            var manager = LevelManager.GetManager();
            
            var holding = Instantiate(HoldingUI, transform);
            manager.HoldingUI = holding.GetComponentInChildren<HoldingUI>();
            manager.HoldingUI.Opened = false;

            var dialog = Instantiate(DialogUI, transform);
            manager.DialogView = dialog.GetComponentInChildren<DialogView>();
            dialog.SetActive(false);

            var loading = Instantiate(LoadingUI, transform);
            manager.LoadingUI = loading.GetComponentInChildren<LoadingUIChaser>();
            loading.SetActive(false);
            
            var pass = Instantiate(LevelPassUI, transform);
            manager.PassUI = pass.GetComponentInChildren<LevelPassUI>();
            pass.SetActive(false);
            
            var fail = Instantiate(LevelFailedUI, transform);
            manager.FailedUI = fail.GetComponentInChildren<LevelFailedUI>();
            fail.SetActive(false);

            Instantiate(CoverageUI, transform);
            
            manager.LoadingUI.OpenScene(InitScenePath);
        }
    }
}