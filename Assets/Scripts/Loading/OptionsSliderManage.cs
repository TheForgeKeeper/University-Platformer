using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class OptionsSliderManage : MonoBehaviour
{
    [SerializeField] private Slider fovSlider;
    [SerializeField] private Slider sensitivitySldier;
    [SerializeField] private Vector2 fovRange = new Vector2(25f, 95f);
    [SerializeField] private Vector2 sensitivityGainRange = new Vector2(3f, 20f);

    [SerializeField] private CinemachineCamera cineCam;
    [SerializeField] private CinemachineInputAxisController cineInputController;
    [SerializeField] private SaveLoadManager saveLoadManager;

    private void Start()
    {
        fovSlider.value = saveLoadManager.loadFOVFromHoisted();
        sensitivitySldier.value = saveLoadManager.loadSensitivityFromHoisted();

        Debug.Log($"Loaded FOV: {saveLoadManager.loadFOVFromHoisted()}, Loaded Sensitivity: {saveLoadManager.loadSensitivityFromHoisted()}");
        cineCam.Lens.FieldOfView = Mathf.Lerp(fovRange.x, fovRange.y, fovSlider.value);

        foreach (var axis in cineInputController.Controllers)
        {
            if (axis.Name == "Look Orbit X" || axis.Name == "Look Orbit Y")
            {
                axis.Input.Gain = Mathf.Lerp(sensitivityGainRange.x, sensitivityGainRange.y, sensitivitySldier.value);
            }
        }
    }

    public void OnFovChange(float value)
    {
        cineCam.Lens.FieldOfView = Mathf.Lerp(fovRange.x, fovRange.y, value);
        saveLoadManager.SaveFOVToHoisted(value);
    }

    public void OnSensitivityChange(float value)
    {
        foreach (var axis in cineInputController.Controllers)
        {
            if(axis.Name == "Look Orbit X" || axis.Name == "Look Orbit Y")
            {
                axis.Input.Gain = Mathf.Lerp(sensitivityGainRange.x, sensitivityGainRange.y, value);
            }
        }
        saveLoadManager.SaveSensitivityToHoisted(value);

    }


}
