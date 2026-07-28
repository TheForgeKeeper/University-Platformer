using UnityEngine;

public class CameraRelay : MonoBehaviour, ICameraRelay
{
    public Vector3 lookDirection => transform.forward;

    public Vector2 CamAdjustInputsXZ(Vector2 rawInput)
    {
        float camRotationY = transform.eulerAngles.y * Mathf.Deg2Rad;
        Vector2 adjustedInput;
        adjustedInput.x = rawInput.x * Mathf.Cos(camRotationY) + rawInput.y * Mathf.Sin(camRotationY);
        adjustedInput.y = -rawInput.x * Mathf.Sin(camRotationY) + rawInput.y * Mathf.Cos(camRotationY);
        return adjustedInput;
    }
}
