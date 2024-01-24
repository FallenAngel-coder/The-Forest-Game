using UnityEngine;

public class CubemapTransition : MonoBehaviour
{
    public Transform lightTransform; // Посилання на трансформ світла
    public float transitionDuration = 3.0f; // Тривалість переходу
    public float rotationSpeed = 3f; // Швидкість обертання

    public Material material; // Посилання на матеріал, який містить параметр _CubemapTransition

    private bool isTransitioning = false;
    private float transitionTimer = 2f;
    private float startValue = 0f;
    private float targetValue = 0f;

    void Update()
    {
        //// Обертання об'єкта по колу вздовж осі X
        //float rotationAmount = rotationSpeed * Time.deltaTime;
        //transform.Rotate(Vector3.right, rotationAmount);

        //// Отримуємо напрямок світла по X
        //float lightRotationX = lightTransform.rotation.eulerAngles.x;

        //// Перевіряємо, чи світло знаходиться в потрібному діапазоні
        //if (lightRotationX >= -5f && lightRotationX <= 175f)
        //{
        //    targetValue = 1f; // Якщо світло в діапазоні, встановлюємо цільове значення 1
        //}
        //else
        //{
        //    targetValue = 0f; // Якщо світло не в діапазоні, встановлюємо цільове значення 0
        //}

        //// Плавний перехід
        //if (targetValue != material.GetFloat("_CubemapTransition"))
        //{
        //    if (!isTransitioning)
        //    {
        //        isTransitioning = true;
        //        startValue = material.GetFloat("_CubemapTransition");
        //        transitionTimer = 0f;
        //    }

        //    transitionTimer += Time.deltaTime;

        //    float t = Mathf.Clamp01(transitionTimer / transitionDuration);
        //    t = Mathf.SmoothStep(startValue, targetValue, t);

        //    material.SetFloat("_CubemapTransition", t);

        //    if (transitionTimer >= transitionDuration)
        //    {
        //        isTransitioning = false;
        //    }
        //}
    }
}   