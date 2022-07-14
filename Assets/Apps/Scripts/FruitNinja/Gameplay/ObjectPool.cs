using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public enum PoolRequestMode {
        OBJECT_ONLY, WITH_ACTIVATION
    }
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
    
        public T RequestInactiveObject<T>(PoolRequestMode mode) {
            foreach(GameObject go in pool) {
                if (go.activeInHierarchy == true) {
                    continue;
                }
                if (go.GetComponent<T>() != null) {
                    if (mode == PoolRequestMode.WITH_ACTIVATION) {
                        Activate(go);
                    }
                    return go.GetComponent<T>();
                }
            }
            return default(T);
        }

        public List<T> RequestInactiveObjects<T>(PoolRequestMode mode) {
            List<T> list = new List<T>();

            foreach(GameObject go in pool) {
                if (go.activeInHierarchy == true) {
                    continue;
                }
                if (go.GetComponent<T>() != null) {
                    if (mode == PoolRequestMode.WITH_ACTIVATION) {
                        Activate(go);
                    }
                    list.Add(go.GetComponent<T>());
                }
            }

            return list;
        }

        private void Activate(GameObject go) {
            go.SetActive(true);
        }
        private void Deactivate(GameObject go) {
            go.SetActive(false);
        }
    }
}
