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

        public void SetOnOutOfBoundaryAction(Action<GameObject> action) {
            boundary.OnOutOfBoundary += action;
        }
        public void SetOnSliceAction(Action<ThrowableObject> action) {
            foreach (ThrowableObject to in pool.RequestInactiveObjects<ThrowableObject>(PoolRequestMode.OBJECT_ONLY)) {
                to.OnSliced_Throwable += action;
            }
        }
        public void SetOnSliceAction() {
            foreach(ThrowableObject to in pool.RequestInactiveObjects<ThrowableObject>(PoolRequestMode.OBJECT_ONLY)) {
                to.OnSliced_Throwable += RemoveFromList;
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
            ThrowableObject to = go.GetComponent<ThrowableObject>();

            if (to == null) {
                return;
            }
            RemoveFromList(to);
        }
        public void RemoveFromList(ThrowableObject to) {
            thrownObjects.Remove(to);
            to.Hide();
        }
        private bool IsAnyActiveObject() {
            if (thrownObjects.Count > 0) {
                return true;
            }
            return false;
        }
        public IEnumerator WaitForAllObjects() {
            while (true) {
                if (!IsAnyActiveObject()) {
                    break;
                }
                yield return null;
            }
        }
    }
}
