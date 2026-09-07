using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelStarDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text starBarTxt;
    [SerializeField] private StarTime[] starTimes = new StarTime[4];

    private void Start()
    {
        starBarTxt.text = " ";
    }

    public void StarBarFromTime(float bestTime)
    {
        string star = "★";
        string emptyStar = "☆";
        string kite = "◇";
        string starBar = "";

        for (int i = starTimes.Length - 1; i >= 0; i--)
        {

            if (bestTime <= starTimes[i].time)
            {
                starBar += i > 0 ? star : kite;
            }
            else
            {
                if (i > 0) starBar += emptyStar;
            }
        }

        starBarTxt.text = starBar;
    }

    public void SetStarBarEmpty()
    {
        starBarTxt.text = "☆☆☆";
    }

    [System.Serializable]
    struct StarTime
    {
        public float time;
        public TMP_Text text;
    }
}
