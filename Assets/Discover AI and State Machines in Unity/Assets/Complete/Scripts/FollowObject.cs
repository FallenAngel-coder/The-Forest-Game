using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow; // Об'єкт, за яким слідкуємо
    public float followSpeed = 5f; // Швидкість "слідування"

    void Update()
    {
        // Перевіряємо, чи встановлений об'єкт для слідкування
        if (objectToFollow != null)
        {
            // Визначаємо нову позицію для поточного об'єкту, щоб він слідував за об'єктом, який ми обрали
            Vector3 newPos = Vector3.Lerp(transform.position, objectToFollow.position, followSpeed * Time.deltaTime);
            transform.position = newPos; // Встановлюємо нову позицію
        }
    }
}
