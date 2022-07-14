using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FruitNinja.Gameplay
{
    public class SlicedEffect : MonoBehaviour {
        public SlicedPiece[] slicedPiece;


        internal void SetInfo(SliceInfo info) {
            transform.position = info.slicedTransform.position;
            transform.rotation = info.slicedTransform.rotation;

            slicedPiece[0].Set(info.slicedTransform, info.rigidBody);
            slicedPiece[1].Set(info.slicedTransform, info.rigidBody);
        }

        internal void Deactivate() {
            gameObject.SetActive(false);
        }
    }
}
