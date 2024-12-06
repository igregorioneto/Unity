using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Duration of a full day in seconds
    [Tooltip("Duration of a full day in seconds.")]
    [SerializeField] private float dayDurationInSeconds = 60f;

    // Axis of rotation
    [Tooltip("The axis around which the light rotates.")]
    [SerializeField] private Vector3 rotationAxis = Vector3.right;

    private float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculate the rotation speed in degrees per second
        rotationSpeed = 360f / dayDurationInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the light around the specified axis
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
