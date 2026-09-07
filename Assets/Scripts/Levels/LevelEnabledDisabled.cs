using UnityEngine;
using UnityEngine.UI;

public class LevelEnabledDisabled : MonoBehaviour
{
    [SerializeField] private Button button;

    public void DisableButton()
    {
        button.interactable = false;
    }

    public void EnableButton()
    {
        button.interactable = true;
    }

}
