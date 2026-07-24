using JdnUtilities;
using System.ComponentModel;
using UnityEngine;

public class UnityDoorScript : MonoBehaviour , IDoor
{
    [SerializeField] private Transform hDoor;
    [SerializeField] private Transform lDoor;
    [SerializeField] private float openHeight = 1.5f;
    [SerializeField] private float animationDuration;
    [SerializeField] private AnimationCurve interpolationCurve;
    
    private bool isDoorOpen = false;

    public void Close()
    {
        isDoorOpen = false;

        Vector3 finalDoorPosition = hDoor.transform.position + (Vector3.down * openHeight);
        StartCoroutine( Interpolator.Interpolate<Vector3>
        (
            () => hDoor.transform.position,
            v => hDoor.transform.position = v,
            finalDoorPosition,
            animationDuration,
            interpolationCurve,
            Vector3.Lerp
        ));

        finalDoorPosition = lDoor.transform.position + (Vector3.up * openHeight);
        StartCoroutine( Interpolator.Interpolate<Vector3>
        (
            () => lDoor.transform.position,
            v => lDoor.transform.position = v,
            finalDoorPosition,
            animationDuration,
            interpolationCurve,
            Vector3.Lerp
        ));

    }


    public bool IsDoorOpen() => isDoorOpen;
    public void Open()
    {
        isDoorOpen = true;
        Debug.Log($"opendoor from {this.gameObject.name}");
        Vector3 finalDoorPosition = hDoor.transform.position + (Vector3.up * openHeight);
        StartCoroutine( Interpolator.Interpolate<Vector3>
        (
            () => hDoor.transform.position,
            v => hDoor.transform.position = v,
            finalDoorPosition,
            animationDuration,
            interpolationCurve,
            Vector3.Lerp
        ));

        finalDoorPosition = lDoor.transform.position + (Vector3.down * openHeight);
        StartCoroutine(Interpolator.Interpolate<Vector3>
        (
            () => lDoor.transform.position,
            v => lDoor.transform.position = v,
            finalDoorPosition,
            animationDuration,
            interpolationCurve,
            Vector3.Lerp
        ));
    }
}
