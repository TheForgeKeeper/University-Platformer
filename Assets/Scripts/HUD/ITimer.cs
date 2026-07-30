namespace JdnUniPlat.HUD
{
    public interface ITimer
    {
        void ResetAndStart();
        void ResetAndStop();
        void StartTimer();
        void StopTimer();
    }
}