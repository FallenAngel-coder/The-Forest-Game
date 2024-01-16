using UnityEngine;
using Cinemachine;

public class ChangeCinemachinePriorityOnMouseHold : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras; // Array of your virtual cameras

    // Method to be called when the right mouse button is held down
    public void DecreasePriorityOnHold()
    {
        if (Input.GetMouseButton(1)) // Check if the right mouse button is held down
        {
            foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
            {
                if (virtualCamera != null)
                {
                    virtualCamera.Priority -= 5; // Decrease the priority by 5
                }
            }
        }
    }

    // Method to be called when the right mouse button is released
    public void IncreasePriorityOnRelease()
    {
        if (Input.GetMouseButtonUp(1)) // Check if the right mouse button is released
        {
            foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
            {
                if (virtualCamera != null)
                {
                    virtualCamera.Priority += 5; // Increase the priority by 5
                }
            }
        }
    }
}