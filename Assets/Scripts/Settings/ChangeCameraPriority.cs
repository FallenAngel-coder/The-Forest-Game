using UnityEngine;
using Cinemachine;

public class ChangeCinemachinePriority : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Посилання на вашу віртуальну камеру Cinemachine

    // Метод, який буде викликаний при натисканні на кнопку для зменшення пріоритету
    public void DecreasePriorityOnClick()
    {
        if (virtualCamera != null)
        {
            virtualCamera.Priority -= 1; // Зменшення пріоритету на 1
        }
    }

    // Метод, який буде викликаний при натисканні на кнопку для збільшення пріоритету
    public void IncreasePriorityOnClick()
    {
        if (virtualCamera != null)
        {
            virtualCamera.Priority += 1; // Збільшення пріоритету на 1
        }
    }
}
