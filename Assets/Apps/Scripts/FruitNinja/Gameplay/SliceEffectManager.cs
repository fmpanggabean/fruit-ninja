using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class SliceEffectManager : MonoBehaviour
    {
        public ObjectPool pool;
        public List<SlicedEffect> slicedEffectColection;
        public Boundary boundary;

        private void Awake() {
            if (pool == null) {
                pool = FindObjectOfType<ObjectPool>();
            }
            if (boundary == null) {
                boundary = FindObjectOfType<Boundary>();
            }
            boundary.OnOutOfBoundary += DeactivateEffect;
        }

        private void Start() {
            SliceActionRegister();
        }

        private void DeactivateEffect(GameObject go) {
            SlicedPiece sp = go.GetComponent<SlicedPiece>();
            if (sp != null) {
                sp.Deactivate();
            }
        }

        private void SliceActionRegister() {
            foreach (Fruit f in pool.RequestInactiveObjects<Fruit>(PoolRequestMode.OBJECT_ONLY)) {
                f.OnSliced += ShowEffect;
            }
        }

        private void ShowEffect(SliceInfo info) {
            SlicedEffect se = pool.RequestInactiveObject<SlicedEffect>(PoolRequestMode.WITH_ACTIVATION);
            se.SetInfo(info);
            slicedEffectColection.Add(se);
        }
    }
}
