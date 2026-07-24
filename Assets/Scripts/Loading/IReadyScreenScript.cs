using UnityEngine;

namespace Assets.Scripts.Loading
{
    public interface IReadyScreenScript
    {
        void InjectData(Canvas isReadyScreenCanvas);
    }
}