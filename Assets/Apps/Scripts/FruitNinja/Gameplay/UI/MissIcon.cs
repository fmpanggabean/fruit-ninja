using UnityEngine;
using UnityEngine.UI;

namespace FruitNinja.Gameplay.UI {
    public class MissIcon : MonoBehaviour {
        public GameObject disabled;
        public GameObject enabled;

        public void Enable() {
            enabled.SetActive(true);
            disabled.SetActive(false);
        }
        public void Disable() {
            enabled.SetActive(false);
            disabled.SetActive(true);
        }
    }
}