using UnityEngine;
using System.Collections.Generic;
using System;

namespace FruitNinja.Gameplay {
    [CreateAssetMenu(fileName = "New Weight Table", menuName = "Scriptable objects/Weight Table")]
    public class WeightTable : ScriptableObject {
        public List<WeightMember> weightTable;

        public string GetRandomedData() {
            float totalWeight = GetTotalWeight();

            foreach(WeightMember wm in weightTable) {
                float rand = UnityEngine.Random.Range(0f, totalWeight);
                if (rand <= wm.weight) {
                    return wm.label;
                } else {
                    totalWeight -= wm.weight;
                }
            }
            
            return "";
        }

        private float GetTotalWeight() {
            float totalWeight = 0;
            foreach (WeightMember wm in weightTable) {
                totalWeight += wm.weight;
            }
            return totalWeight;
        }
    } 
}