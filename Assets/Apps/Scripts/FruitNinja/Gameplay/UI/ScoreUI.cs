using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FruitNinja.Gameplay.UI
{
    public class ScoreUI : BaseUI, IGameUI
    {
        public TMP_Text text;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Start() {
            GameManager.OnScoreUpdated += SetScore;
        }
        public void SetScore(int score) {
            text.text = score.ToString();
        }
    }
}
