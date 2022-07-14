using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class Boundary : MonoBehaviour
    {
        public event System.Action<GameObject> OnOutOfBoundary;

        private void OnTriggerExit(Collider other) {
            OnOutOfBoundary?.Invoke(other.gameObject);
        }
    }
}
