namespace FruitNinja.Gameplay.UI {
    public abstract class BaseUI : UnityEngine.MonoBehaviour{

        public void Hide() {
            gameObject.SetActive(false);
        }
        public void Show() {
            gameObject.SetActive(true);
        }
    }
}