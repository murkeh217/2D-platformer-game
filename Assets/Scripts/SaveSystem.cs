using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveSystem 
{
    public static void SaveData(LobbyController level) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leveldata.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(level);
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(data.level);
        Debug.Log("Game has been saved...");
    }
    
    public static LevelData LoadData() 
    {
        string path = Application.persistentDataPath + "/leveldata.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            Debug.Log("Loading existing game...");
            Debug.Log(data.level);
            return data;
         }
        else 
        {
            Debug.LogError("Save file not found in " + path);
            Debug.Log("Loading new game...");
            SceneManager.LoadScene(1);
            return null;
        }
    }
}
