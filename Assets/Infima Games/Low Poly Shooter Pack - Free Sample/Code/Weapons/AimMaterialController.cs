using UnityEngine;
using Cinemachine;

public class AimMaterialController : MonoBehaviour
{
    public Camera aimCamera;
    public Renderer targetRenderer;
    public Material aimMaterial;
    public Material originalMaterial;

    void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Renderer не знайдено. Додайте Renderer до об'єкта або встановіть посилання в інспекторі.");
            enabled = false;
            return;
        }

        originalMaterial = targetRenderer.material;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            OnAimStop();
        }
        else
        {
            OnAim();
        }
    }

    void OnAim()
    {
        // Вимкнути aimCamera при прицілюванні


        // Змінити матеріал при прицілюванні
        targetRenderer.material = aimMaterial;
    }

    void OnAimStop()
    {
        // Вмикнути aimCamera при припиненні прицілювання
        aimCamera.enabled = true;

        // Повернути початковий матеріал при відпусканні кнопки
        targetRenderer.material = originalMaterial;
    }
}
