using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSliderManage : MonoBehaviour
{
    [SerializeField] private Slider fovSlider;
    [SerializeField] private Slider sensitivity;
    [SerializeField] private Vector2 fovRange = new Vector2(25f, 95f);
    [SerializeField] private Vector2 sensitivityGainRange = new Vector2(3f, 20f);

    [SerializeField] private CinemachineCamera cineCam;
    [SerializeField] private CinemachineInputAxisController cineInputController;

    private void Start()
    {
        fovSlider.value = Mathf.InverseLerp(fovRange.x, fovRange.y, cineCam.Lens.FieldOfView);
        sensitivity.value = Mathf.InverseLerp(sensitivityGainRange.x, sensitivityGainRange.y, cineInputController.Controllers[0].Input.Gain);
    }

    public void OnFovChange(float value)
    {
        
        cineCam.Lens.FieldOfView = Mathf.Lerp(fovRange.x, fovRange.y, value);
    }

    public void OnSensitivityChange(float value)
    {
        Debug.Log("Sensitivity changed to: " + value);
        foreach (var axis in cineInputController.Controllers)
        {
            if(axis.Name == "Look Orbit X" || axis.Name == "Look Orbit Y")
            {
                axis.Input.Gain = Mathf.Lerp(sensitivityGainRange.x, sensitivityGainRange.y, value);
            }
        }
    }
}
