using UnityEngine;

public class MoveAndDelete : MonoBehaviour
{
    public AnimationCurve moveCurve; // Крива для контролю швидкості підйому
    public float moveDuration = 3f; // Тривалість підйому
    public float deleteAfter = 3f; // Час перед видаленням об'єкта

    public float elapsedTime = 0f;
    public bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        elapsedTime += Time.deltaTime;

        // Рух об'єкта за кривою
        float yPos = moveCurve.Evaluate(elapsedTime / moveDuration);
        transform.Translate(Vector3.up * yPos * Time.deltaTime);

        // Якщо час підйому завершився, зупиняємо рух та запускаємо таймер для видалення об'єкта
        if (elapsedTime >= moveDuration)
        {
            isMoving = false;
            Invoke("DeleteObject", deleteAfter);
        }
    }

    void DeleteObject()
    {
        // Видаляємо об'єкт
        Destroy(gameObject);
    }
}
