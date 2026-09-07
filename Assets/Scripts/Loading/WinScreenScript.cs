using JdnUniPlat.HUD;
using TMPro;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    [SerializeField] private int levelIndex = 0;
    [SerializeField] private SaveLoadManager saveLoadManager;
    [SerializeField] private Timer timer;

    [SerializeField] private TMP_Text currentScoretxt;
    [SerializeField] private TMP_Text bestScore;
    [SerializeField] private TMP_Text starBartxt;

    [SerializeField] private Color AcheivedColor = Color.limeGreen;
    [SerializeField] private Color AcheivedThisRunColor = Color.skyBlue;


    [SerializeField] private StarTime[] starTimes = new StarTime[4];


    private string star = "★";
    private string emptyStar = "☆";
    private string kite = "◇";

    private void Start()
    {
        for(int i = 0; i < starTimes.Length;i++)
        {
            if(i == 0)
            {
                starTimes[i].text.text = kite + " " + starTimes[i].time.ToString("f2");
            }
            else
            {
                starTimes[i].text.text = star + " " + starTimes[i].time.ToString("f2");
            }
        }
    }

    public void OnWin()
    {
        float currentScore = timer.GetTimePassed();
        LevelData currentLevelData = saveLoadManager.LoadLevelFromHoisted(levelIndex);


        if (currentScore < currentLevelData.bestTime)
        {
            currentLevelData.bestTime = currentScore;
            currentLevelData.isCompleted = true;
            saveLoadManager.SaveLevelToHoisted(levelIndex, currentLevelData);
            saveLoadManager.SaveHoistedData();
        }
        bestScore.text = ((currentLevelData.bestTime < starTimes[0].time) ? kite : star) + " " + currentLevelData.bestTime.ToString("f2");
        currentScoretxt.text = ((currentScore < starTimes[0].time) ? kite : star) + " " + currentScore.ToString("f2");

        string starBar = "";

        for (int i = starTimes.Length - 1; i >= 0; i--)
        {
            if (currentLevelData.bestTime <= starTimes[i].time) starTimes[i].text.color = AcheivedColor;

            if (currentScore <= starTimes[i].time)
            {
                starBar += i > 0 ? star : kite;
                if(currentScore <= starTimes[i].time) starTimes[i].text.color = AcheivedThisRunColor;
            }
            else
            {
                if (i > 0) starBar += emptyStar;
            }
        }

        starBartxt.text = starBar;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    [System.Serializable]
    struct StarTime
    {
        public float time;
        public TMP_Text text;
    }

}
