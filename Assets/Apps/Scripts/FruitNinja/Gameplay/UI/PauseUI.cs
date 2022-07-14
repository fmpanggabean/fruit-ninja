using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class PauseUI : BaseUI {
        public Button pauseButton;
        public GameObject pauseScreen;
        public Button resumeButton;

        private void Awake() {
            pauseButton.onClick.AddListener(ShowPauseScreen);
            resumeButton.onClick.AddListener(HidePauseScreen);
        }
        private void Start() {
            HidePauseScreen();
        }

        internal void SetPauseAction(Action pauseGame) {
            pauseButton.onClick.AddListener(pauseGame.Invoke);
        }

        internal void SetResumeAction(Action resumeGame) {
            resumeButton.onClick.AddListener(resumeGame.Invoke);
        }
        private void HidePauseScreen() {
            pauseScreen.SetActive(false);
        }
        private void ShowPauseScreen() {
            pauseScreen.SetActive(true);
        }
    }
}