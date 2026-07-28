using UnityEngine;

public interface ICameraRelay
{
    /// <returns> The direction the camera is looking at </returns>
    Vector3 lookDirection { get; }

    /// <summary>
    /// Changes the given global raw input to face in the direction the camera is facing 
    /// </summary>
    /// <param name="rawInput"> input In global (horizontal,vertical) </param>
    /// <returns> adjusted input vector </returns>
    Vector2 CamAdjustInputsXZ(Vector2 rawInput);
}