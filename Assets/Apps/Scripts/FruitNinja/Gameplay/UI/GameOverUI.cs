using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class GameOverUI : BaseUI, IGameUI {
        public Button returnButton;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Start() {
            GameManager.OnGameOver += Show;
            SetReturnAction(GameManager.ReturnToMainMenu);
            Hide();
        }
        internal void SetReturnAction(Action returnToMainMenu) {
            returnButton.onClick.AddListener(returnToMainMenu.Invoke);
        }
    }
}