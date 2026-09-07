using System.IO;
using UnityEngine;

public class 
    SaveLoadManager : MonoBehaviour
{
    private UniPlatData hoistedData;

    private void Awake()
    {
        hoistedData = loadData();
    }

    [System.Serializable]
    private struct UniPlatData
    {
        public levelData[] levels;
        public float FOV;
        public float Sensitivity;
    }

    public levelData LoadLevelFromHoisted(int levelIndex)
    {
        return hoistedData.levels[levelIndex];
    }

    public float loadFOVFromHoisted()
    {
        return hoistedData.FOV;
    }

    public float loadSensitivityFromHoisted()
    {
        return hoistedData.Sensitivity;
    }

    private void OnApplicationQuit()
    {
        SaveHoistedData();
    }

    public void SaveLevelToHoisted(int levelIndex, levelData data)
    {
        hoistedData.levels[levelIndex] = data;
    }

    public void SaveFOVToHoisted(float fov)
    {
        hoistedData.FOV = fov;
    }

    public void SaveSensitivityToHoisted(float sensitivity)
    {
        hoistedData.Sensitivity = sensitivity;
    }

    public void SaveHoistedData()
    {
        string json = JsonUtility.ToJson(hoistedData);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    private UniPlatData loadData()
    {
        try
        {
            string data = File.ReadAllText(Application.persistentDataPath + "/saveData.json");
            
            if (data is string json)
            {
                
                return JsonUtility.FromJson<UniPlatData>(json);
            }
            else
            {
                Debug.LogWarning("SaveLoadManager: save data not json, creating new data.");
                return EmptyUniPlatData();
            }
        }
        catch (FileNotFoundException)
        {
            Debug.LogWarning("SaveLoadManager: save data not found, creating new data.");
            return EmptyUniPlatData();
        }
    }

    private UniPlatData EmptyUniPlatData()
    {
        UniPlatData data = new UniPlatData();
        data.levels = new levelData[6];
        for (int i = 0; i < data.levels.Length; i++)
        {
            data.levels[i] = new levelData() { bestTime = float.MaxValue, isCompleted = false };
        }
        data.FOV = .4f;
        data.Sensitivity = .4f;
        return data;
    }
}

[System.Serializable]
public struct levelData
{
    public float bestTime;
    public bool isCompleted;
}
