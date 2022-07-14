using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> prefabs;
        public List<GameObject> pool { get; private set; }
        [SerializeField] private int poolRange;

        private void Awake() {
            pool = new List<GameObject>();

            GeneratePool();
        }

        private void GeneratePool() {
            foreach(GameObject go in prefabs) {
                for (int i=0; i<poolRange; i++) {
                    pool.Add(Instantiate(go, transform));
                    pool[pool.Count - 1].SetActive(false);
                }
            }
        }
    
        public T RequestInactiveObject<T>() {
            foreach(GameObject go in pool) {
                if (go.GetComponent<T>() != null) {
                    return go.GetComponent<T>();
                }
            }
            return default(T);
        }

        public List<T> RequestInactiveObjects<T>() {
            List<T> list = new List<T>();

            foreach(GameObject go in pool) {
                if (go.GetComponent<T>() != null) {
                    list.Add(go.GetComponent<T>());
                }
            }

            return list;
        }

    }
}
