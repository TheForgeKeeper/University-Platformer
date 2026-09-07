using System.Collections;
using UnityEngine;


public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private int levelIndex;
    [SerializeField] private SaveLoadManager saveLoadManager;
    [SerializeField] private LevelEnabledDisabled levelEnabledDisabled;
    [SerializeField] private LevelStarDisplay levelStarDisplay;

    void Start()
    {
        LevelData levelData = saveLoadManager.LoadLevelFromHoisted(levelIndex);

        if(levelData.isCompleted)
        {
            levelEnabledDisabled.EnableButton();
            levelStarDisplay.StarBarFromTime(levelData.bestTime);
        }
        else
        {
            if (levelIndex == 0 || saveLoadManager.LoadLevelFromHoisted(levelIndex - 1).isCompleted)
            {
                levelEnabledDisabled.EnableButton();
                levelStarDisplay.SetStarBarEmpty();
            }
            else
            {
                levelEnabledDisabled.DisableButton();
            }
        }
    }

}

