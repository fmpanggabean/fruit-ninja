using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class PauseUI : BaseUI, IGameUI {
        public Button pauseButton;
        public GameObject pauseScreen;
        public Button resumeButton;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Awake() {
            pauseButton.onClick.AddListener(ShowPauseScreen);
            resumeButton.onClick.AddListener(HidePauseScreen);
            SetPauseAction(GameManager.PauseGame);
            SetResumeAction(GameManager.ResumeGame);
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