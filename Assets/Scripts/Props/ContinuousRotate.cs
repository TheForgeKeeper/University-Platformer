using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private bool Y = true;
    [SerializeField] private List<RotationData> axes;

    private Transform doorTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Y) transform.localRotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);
        foreach(RotationData data in axes)
        {
            transform.localRotation *= Quaternion.AngleAxis(data.speed * Time.deltaTime, data.axis);
        }
    }

    [System.Serializable]
    struct RotationData
    {
        public float speed;
        public Vector3 axis;
    }
}
