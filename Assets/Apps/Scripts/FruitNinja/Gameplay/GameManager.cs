using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FruitNinja.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public ThrowManager throwManager;
        public SliceEffectManager sliceEffectManager;

        public event Action<int> OnScoreUpdated;
        public event Action<int> OnMissUpdated;
        public event Action OnGameOver;
        public event Action OnPaused;

        public int score;
        public int miss;
        public bool isPlaying;

        private void Awake() {
            if (throwManager == null) {
                throwManager = FindObjectOfType<ThrowManager>();
            }
        }
        private void Start() {
            throwManager.SetOnSliceAction();
            throwManager.SetOnSliceAction(AddScore);
            throwManager.SetOnOutOfBoundaryAction(AddMiss);

            sliceEffectManager.SliceActionRegister();

            StartCoroutine(GameLoop());
        }

        private void AddMiss(GameObject obj) {
            Fruit f = obj.GetComponent<Fruit>();

            if (f == null) {
                return;
            }

            miss++;
            OnMissUpdated?.Invoke(miss);
            
            if (miss >= 3) {
                GameOver();
            }
        }

        private IEnumerator GameLoop() {
            float delay = 0;
            int throwCount = 0;
            isPlaying = true;

            while (isPlaying) {
                throwCount = GetRandomThrowCount(2, 6);
                delay = 1f / (float)throwCount;
                for (int i=0; i<throwCount; i++) {
                    throwManager.ThrowRandom();
                    yield return new WaitForSeconds(delay);
                }

                yield return throwManager.WaitForAllObjects();
                yield return new WaitForSeconds(1f);
            }
        }

        private void AddScore(ThrowableObject throwableObject) {
            if (throwableObject.GetType() == typeof(Fruit)) {
                score++;
                OnScoreUpdated?.Invoke(score);
            } else {
                GameOver();
            }
        }

        private void GameOver() {
            OnGameOver?.Invoke();
            CompareScore();
        }

        private void CompareScore() {
            SaveData sd = SaveLoad.Load();

            if (score > sd.highscore) {
                sd.highscore = score;
                SaveLoad.Save(sd);
            }
        }

        public void PauseGame() {
            Time.timeScale = 0;
        }
        public void ResumeGame() {
            Time.timeScale = 1;
        }

        private int GetRandomThrowCount(int v1, int v2) {
            return UnityEngine.Random.Range(v1, v2);
        }
        public void ReturnToMainMenu() {
            SceneManager.LoadScene(0);
        }
    }
}
