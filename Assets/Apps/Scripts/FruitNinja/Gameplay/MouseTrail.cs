using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class MouseTrail : MonoBehaviour
    {
        public GameObject mouseTrail;
        private Vector3 mousePosition;

        private void Update() {
            if (Input.GetMouseButton(0)) {
                mouseTrail.SetActive(true);
            } else {
                mouseTrail.SetActive(false);
            }
            PositionUpdate();
        }

        private void PositionUpdate() {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;

            Vector3 trailPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = trailPosition;
        }
    }
}
