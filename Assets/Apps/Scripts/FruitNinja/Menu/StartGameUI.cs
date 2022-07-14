using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Menu
{
    public class StartGameUI : BaseUI
    {
        public Button startButton;

        internal void SetStartAction(Action startGame) {
            startButton.onClick.AddListener(startGame.Invoke);
        }
    }
}
