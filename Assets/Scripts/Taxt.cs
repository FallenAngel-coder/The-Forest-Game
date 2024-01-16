using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Taxt : MonoBehaviour
{
    public UnityEvent _onClickEvent;

    private Vector3 startScale;

    public float scaleFactor = 1.5f; // Фактор збільшення розміру

    private void Awake()
    {
        startScale = transform.localScale; // Зберігаємо початковий розмір об'єкта
    }

    private void OnMouseEnter()
    {
        // Збільшуємо розмір об'єкта при наведенні миші
        transform.localScale = startScale * scaleFactor;
    }

    private void OnMouseExit()
    {
        // Повертаємо об'єкт до звичайного розміру при відведенні миші
        transform.localScale = startScale;
    }

    private void OnMouseDown()
    {
        // Логіка для обробки події кліку миші, якщо потрібно
        _onClickEvent.Invoke();
    }
}
