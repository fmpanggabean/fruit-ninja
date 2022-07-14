using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class ThrowManager : MonoBehaviour
    {
        [SerializeField] private ObjectPool pool;
        [Range(1, 30)] public float throwPower;
        public WeightTable throwData;
        public Boundary boundary;

        [SerializeField] private List<ThrowableObject> thrownObjects;


        private void Awake() {
            thrownObjects = new List<ThrowableObject>();
            
            if (boundary == null) {
                boundary = FindObjectOfType<Boundary>();
            }
            boundary.OnOutOfBoundary += RemoveFromList;
        }
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ThrowRandom();
            }
        }

        public void ThrowRandom() {
            Throw(throwData.GetRandomedData());
        }
        public void Throw(string label) {
            ThrowableObject to;
            
            if (label == "Bomb") {
                to = pool.RequestInactiveObject<Bomb>(PoolRequestMode.WITH_ACTIVATION);
            } else {
                to = pool.RequestInactiveObject<Fruit>(PoolRequestMode.WITH_ACTIVATION);
            }
            to.Init(transform);
            to.Throw(throwPower);

            thrownObjects.Add(to);
        }
        public void RemoveFromList(GameObject go) {
            thrownObjects.Remove(go.GetComponent<ThrowableObject>());
        }
    }
}
