using TMPro;
using UnityEngine;

namespace JdnUniPlat.HUD
{
    public class Timer : MonoBehaviour, ITimer
    {
        [SerializeField] private TMP_Text timerText;

        private float timeSinceStart = 0;
        private bool isTimerRunning = false;

        private void Update()
        {
            if (isTimerRunning) timeSinceStart += Time.deltaTime;
            UpdateUI();
        }

        private void UpdateUI()
        {
            timerText.text = $"{Mathf.Round(timeSinceStart * 100) / 100}";
        }

        public void StartTimer()
        {
            isTimerRunning = true;
        }

        public void StopTimer()
        {
            isTimerRunning = false;
        }

        public void ResetAndStop()
        {
            timeSinceStart = 0;
            isTimerRunning = false;
        }
        public void ResetAndStart()
        {
            timeSinceStart = 0;
            isTimerRunning = true;
        }
    }
}