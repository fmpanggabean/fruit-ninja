using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

namespace FruitNinja.Menu
{
    public class MenuManager : MonoBehaviour
    {
        private List<BaseUI> uiCollection;

        private void Awake() {
            uiCollection = FindObjectsOfType<BaseUI>().ToList();

            GetUI<StartGameUI>().SetStartAction(StartGame);
        }
        private void Start() {
            LoadHighscore();
        }

        public T GetUI<T>() where T : BaseUI {
            foreach(BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }
        public void StartGame() {
            SceneManager.LoadScene(1);
        }
        public void LoadHighscore() {
            GetUI<HighscoreUI>().SetScore(SaveLoad.Load());
        }
    }
}
