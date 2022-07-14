using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FruitNinja.Gameplay;

namespace FruitNinja.Gameplay.UI
{
    public class UIManager : MonoBehaviour
    {
        public GameManager gameManager;

        private List<BaseUI> uiCollection;

        private void Awake() {
            uiCollection = FindObjectsOfType<BaseUI>().ToList();

            gameManager.OnScoreUpdated += GetUI<ScoreUI>().SetScore;
            gameManager.OnMissUpdated += GetUI<MissUI>().SetMiss;
            GetUI<PauseUI>().SetPauseAction(gameManager.PauseGame);
            GetUI<PauseUI>().SetResumeAction(gameManager.ResumeGame);
            gameManager.OnGameOver += GetUI<GameOverUI>().Show;
            GetUI<GameOverUI>().SetReturnAction(gameManager.ReturnToMainMenu);
        }
        public T GetUI<T>() where T : BaseUI {
            foreach (BaseUI ui in uiCollection) {
                if (ui.GetType() == typeof(T)) {
                    return (T)ui;
                }
            }
            return null;
        }
    }
}
