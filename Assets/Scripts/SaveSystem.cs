using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{


    public static void SaveGameData(LevelManager levelManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.yee";
        Debug.Log(Application.persistentDataPath);
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(levelManager);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Game saved");
    }

    public static GameData LoadGameData()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/gamedata.yee";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            Debug.Log("Load successful");
            return data;
        }
        else
        {
            Debug.Log("Save fie not found in " + path);
            return null;
        }
    }
}
