using System;
using UnityEngine;

namespace FruitNinja.Gameplay {
    public class SlicedPiece : MonoBehaviour {
        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        internal void Set(Transform slicedTransform, Rigidbody _rb) {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            rb.velocity = _rb.velocity;
            rb.angularVelocity = _rb.angularVelocity;
        }

        internal void Deactivate() {
            GetComponentInParent<SlicedEffect>().Deactivate();
        }

        internal SlicedEffect GetSlicedEffect() {
            return transform.parent.GetComponent<SlicedEffect>();
        }
    }
}