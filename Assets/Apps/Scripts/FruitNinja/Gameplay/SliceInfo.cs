using UnityEngine;

namespace FruitNinja.Gameplay {
    public class SliceInfo {
        public Transform slicedTransform { get; private set; }
        public Rigidbody rigidBody { get; private set; }

        public SliceInfo(ThrowableObject throwableObject) {
            slicedTransform = throwableObject.transform;
            rigidBody = throwableObject.GetComponent<Rigidbody>();
        }
    }
}