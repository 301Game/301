using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveLoadSystem
{
    public static string path = Application.persistentDataPath + "/data.data";
    public static void SaveData(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream outStream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);
        formatter.Serialize(outStream, data);
        outStream.Close();
    }

    public static GameData LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream inStream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(inStream) as GameData;
            return data;
        }
        else
        {
            Debug.LogError("Î´ÕÒµ½´æµµÎÄ¼þ");
            return null;
        }
    }
}
