using TMPro;
using UnityEngine;

public class FpsWrite : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    private float fpsNumerator;
    private float fpsDenominator;
    private float fps1perc;
    private float fps1percCache;

    private void Update()
    {
        float fps = 1.0f / Time.deltaTime;
        fpsNumerator += fps;
        fpsDenominator += 1.0f;

        if(fps < fps1perc || fps1perc == -1f)
        {
            fps1perc = fps;
        }

        if(Time.frameCount % 100 == 0)
        {

            fps1percCache = fps1perc;
            fps1perc = -1f;
        }

        if (Time.frameCount % 15 == 0)
        {
            displayText.text = $"{(fpsNumerator / fpsDenominator):F1} {fps1percCache:F1}";
            fpsNumerator = 0.0f;
            fpsDenominator = 0.0f;
        }
    }
}
