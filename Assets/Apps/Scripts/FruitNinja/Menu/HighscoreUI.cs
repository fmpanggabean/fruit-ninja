using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace FruitNinja.Menu {
    public class HighscoreUI : BaseUI {
        public TMP_Text text;

        internal void SetScore(SaveData saveData) {
            text.text = saveData.highscore.ToString();
        }
    }
}