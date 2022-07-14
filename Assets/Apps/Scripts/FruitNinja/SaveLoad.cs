using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FruitNinja {
    [System.Serializable]
    public class SaveData {
        public int highscore;

        public SaveData() {
            highscore = 0;
        }
    }
    public static class SaveLoad {
        public static string path = Application.persistentDataPath + "/hs.dat";

        public static void Save(SaveData data) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Create);

            bf.Serialize(file, data);
            file.Close();
        }
        public static SaveData Load() {
            if (File.Exists(path)) {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);

                SaveData sd = (SaveData)bf.Deserialize(file);
                file.Close();
                return sd;
            } else {
                Debug.Log("save file not found");
                return new SaveData();
            }
        }
    }
}