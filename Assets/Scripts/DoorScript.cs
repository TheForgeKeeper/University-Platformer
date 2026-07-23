using UnityEngine;
using System.Collections.Generic;

public class DoorScript : MonoBehaviour , IDoor
{
    [SerializeField] private List<Animator> doorAnimator;

    private bool doorState = false; // false = closed, true = open

    public void Open()
    {
        foreach (Animator animator in doorAnimator)
        {
            animator.SetBool("doorOpen", true);
            doorState = true;
        }
    }

    public void Close()
    {
        foreach (Animator animator in doorAnimator)
        {
            animator.SetBool("doorOpen", false);
            doorState = false;
        }
    }

    public bool IsDoorOpen()
    {
        return doorState;
    }
}
