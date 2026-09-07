using UnityEngine;

public class LoadFarthestLevel : MonoBehaviour
{
    [SerializeField] private SaveLoadManager saveLoadManager;
    [SerializeField] private levelIndexMap[] levelIndexMaps;
    [SerializeField] private int totalLevels = 2;

    private void OnValidate()
    {
        if (levelIndexMaps == null || levelIndexMaps.Length != totalLevels)
        {
            levelIndexMap[] levelMapsCached = levelIndexMaps.Clone() as levelIndexMap[];
            levelIndexMaps = new levelIndexMap[totalLevels];

            for (int i = 0; i < totalLevels; i++)
            {
                levelIndexMaps[i].levelName = "Level " + (i + 1);
            }
        }
        
    }

    public void LoadFarthestLevelScene()
    {
        bool levelFound = false;
        
        foreach(var levelMap in levelIndexMaps)
        {
            if (!saveLoadManager.LoadLevelFromHoisted(levelMap.levelIndex).isCompleted)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(levelMap.sceneIndex);
                levelFound = true;
                break;
            }
        }

        if(!levelFound) UnityEngine.SceneManagement.SceneManager.LoadScene(totalLevels - 1);
    }

    [System.Serializable] 
    struct levelIndexMap
    {
        public string levelName;
        public int levelIndex;
        public int sceneIndex;
    }
}
