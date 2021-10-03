using System;
using System.Collections;
using UnityEngine;

namespace PlayModule.Dialog
{
    
    public class DialogController : MonoBehaviour
    {
        private int frame = 0;
        public DialogBlock[] Blocks;
        private DialogView View;
        private int mCurrentLine;

        private void Start()
        {
            mCurrentLine = 0;
            View = LevelManager.GetManager().DialogView;
            View.OnNextLineCalled += OnNextLine;
            OnNextLine(View);
            View.Show();
        }

        private void Update()
        {
            if (View.CanNextLine && Input.GetKeyDown(KeyCode.Return))
                OnNextLine(View);
        }

        private void OnNextLine(DialogView view)
        {
            if (mCurrentLine >= Blocks.Length)
            {
                View.OnNextLineCalled -= OnNextLine;
                View.Hide();
                return;
            }

            var line = Blocks[mCurrentLine];
            view.SetDialog(line.LeftImage, line.RightImage, line.Name, line.Text);
            mCurrentLine++;
        }
        
    }
}