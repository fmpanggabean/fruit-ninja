using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class MissUI : BaseUI, IGameUI {
        public MissIcon[] missIcon;

        public GameManager GameManager => FindObjectOfType<GameManager>();

        private void Start() {
            GameManager.OnMissUpdated += SetMiss;
        }
        public void SetMiss(int miss) {
            for (int i=0; i<3; i++) {
                if (i < miss) {
                    missIcon[i].Disable();
                } else {
                    missIcon[i].Enable();
                }
            }
        }
    }
}