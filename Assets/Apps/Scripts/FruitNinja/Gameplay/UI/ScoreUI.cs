using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FruitNinja.Gameplay.UI
{
    public class ScoreUI : BaseUI
    {
        public TMP_Text text;

        public void SetScore(int score) {
            text.text = score.ToString();
        }
    }
}
