using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class GameOverUI : BaseUI {
        public Button returnButton;

        private void Start() {
            Hide();
        }
        internal void SetReturnAction(Action returnToMainMenu) {
            returnButton.onClick.AddListener(returnToMainMenu.Invoke);
        }
    }
}