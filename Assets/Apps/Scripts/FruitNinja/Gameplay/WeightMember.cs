namespace FruitNinja.Gameplay {
    [System.Serializable]
    public class WeightMember {
        public string label;

        [UnityEngine.Range(0, 100)]
        public float weight;
    }
}