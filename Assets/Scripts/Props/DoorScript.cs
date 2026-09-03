using UnityEngine;
using JdnUtilities;

public class DoorScript : MonoBehaviour , IDoor
{
    [SerializeField] private float degreesToOpen = 90f; // Degrees to rotate when opening the door
    [SerializeField] private float animationDuration = 1f;
    [SerializeField] private AnimationCurve interpolationCurve;
   
    private Quaternion closedRotation;
    private Quaternion openedRotation;
    private bool isDoorOpen = false;
    private Coroutine animationCoroutine;

    public void Close()
    {
        if(animationCoroutine != null) StopCoroutine(animationCoroutine);
        transform.rotation = openedRotation;

        animationCoroutine = StartCoroutine(JdnCoroutines.Interpolate(
            () => transform.rotation,
            (Quaternion q) => transform.rotation = q,
            closedRotation,
            animationDuration,
            interpolationCurve,
            Quaternion.SlerpUnclamped
        ));

        isDoorOpen = false;
    }

    public bool IsDoorOpen()
    {
        return isDoorOpen;
    }

    public void Open()
    {
        if (animationCoroutine != null) StopCoroutine(animationCoroutine);
        transform.rotation = closedRotation;

        animationCoroutine = StartCoroutine(JdnUtilities.JdnCoroutines.Interpolate(
            () => transform.rotation,
            (Quaternion q) => transform.rotation = q,
            openedRotation,
            animationDuration,
            interpolationCurve,
            Quaternion.SlerpUnclamped
            ));
        isDoorOpen = true;
    }

    private void Start()
    {
        closedRotation = transform.rotation;
        openedRotation = closedRotation * Quaternion.AngleAxis(degreesToOpen, Vector3.up);
    }

}
