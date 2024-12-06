using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator doorAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Animator component attached to the same GameObject as this script
        doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (or another specified object)
        if (other.CompareTag("Player"))
        {
            if (doorAnimator != null)
            {
                // Trigger the Door_Open animation
                doorAnimator.SetTrigger("Door_Open");
            }
        }
    }
}
