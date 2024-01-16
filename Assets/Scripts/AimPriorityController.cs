using UnityEngine;
using Cinemachine;

public class AimPriorityController : MonoBehaviour
{
    public CinemachineVirtualCamera aimCamera;
    private int initialPriority;
    private const int priorityIncrease = 5;

    void Start()
    {
        // Зберегти початковий пріоритет камери прицілу
        initialPriority = aimCamera.m_Priority;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // Перевірка на натискання правої кнопки миші
        {
            // Збільшити пріоритет віртуальної камери прицілу
            aimCamera.m_Priority = initialPriority + priorityIncrease;
        }
        else
        {
            // Повернути пріоритет до початкового значення при відпусканні кнопки
            aimCamera.m_Priority = initialPriority;
        }
    }
}
