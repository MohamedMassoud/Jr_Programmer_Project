using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static Color teamColor;
    public static MainManager mainManagerInstance;

    private void Awake()
    {
        if(mainManagerInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        mainManagerInstance = this;
        DontDestroyOnLoad(this);
        LoadColor();
    }

    [System.Serializable]
    public class SaveData
    {
        public Color teamColor;
    }

    public static void SaveColor()
    {
        SaveData saveData = new SaveData();
        saveData.teamColor = teamColor;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            teamColor = saveData.teamColor;
        }
    }
}
