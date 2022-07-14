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

        private List<ThrowableObject> thrownObjects;


        private void Awake() {
            thrownObjects = new List<ThrowableObject>();
        }
        public void ThrowRandom() {
            Throw(throwData.GetRandomedData());
        }
        public void Throw(string label) {
            ThrowableObject to;
            
            if (label == "Bomb") {
                to = pool.RequestInactiveObject<Bomb>();
            } else {
                to = pool.RequestInactiveObject<Fruit>();
            }
            to.Init(transform);
            to.Throw(throwPower);

            thrownObjects.Add(to);
        }
    }
}
