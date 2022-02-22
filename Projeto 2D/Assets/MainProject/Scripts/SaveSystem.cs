using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace MainProject.Scripts
{
    public static class SaveSystem
    {
        private const string SavePath = "/SaveData";

        public static void SaveGame(MainProject.Scripts.PlayerData data)
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + SavePath;
            Debug.Log(path);
            var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadData()
        {
            var path = Application.persistentDataPath + SavePath;

            if (!File.Exists(path)) return null;

            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        }
    }
}
