using UnityEngine;
using UnityEngine.Splines;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;

    private Transform doorTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
    }
}
