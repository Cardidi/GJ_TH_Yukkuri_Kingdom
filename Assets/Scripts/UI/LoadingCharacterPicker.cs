using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI
{
    public class LoadingCharacterPicker : MonoBehaviour
    {
        public Image CharacterImage;
        public Sprite[] CharacterSprites;
        public bool EnableSpaceSwitch = false;

        public void SetCharacter()
        {
            CharacterImage.sprite = CharacterSprites[Random.Range(0, CharacterSprites.Length)];
        }

        private void OnEnable()
        {
            SetCharacter();
        }

        private void Update()
        {
            if (EnableSpaceSwitch && Input.GetKeyDown(KeyCode.Space))
                SetCharacter();
        }
    }
}