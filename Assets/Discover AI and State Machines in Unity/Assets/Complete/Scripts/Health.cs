﻿using IndicatorsHealth;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField]
    public Indicators Indicators;
    [SerializeField]
    public string deathSceneName;
    [SerializeField]
    public Image damageImage; // Посилання на зображення для відображення шкоди
    [SerializeField]
    public AnimationCurve fadeCurve; // AnimationCurve для згладження зникнення зображення шкоди

    void Start()
    {
        Indicators.UpdateHealthE += UpdateHealthUI;
    }

    public void SetHealth(int amount = 100)
    {
        Indicators.healthAmount = amount;
        maxHealth = amount;
        OnHealthChange();
    }
    void UpdateHealthUI()
    {
        if (Indicators.healthAmount <= 0)
            OnDeath();
        TakeDamageDelayed(0, 0);
    }
    void Heal(int amount)
    {
        Indicators.healthAmount = Mathf.Min(Indicators.healthAmount + amount, maxHealth);
        OnHealthChange();
    }

    void OnHealthChange()
    {
        Indicators.UpdateHealth();

    }

    public IEnumerator TakeDamageDelayed(float amount, float delay)
    {
        // Показати зображення шкоди
        damageImage.gameObject.SetActive(true);
        float elapsedTime = 0f;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(elapsedTime / delay);
            Color imageColor = damageImage.color;
            imageColor.a = alpha;
            damageImage.color = imageColor;
            yield return null;
        }

        Indicators.healthAmount = Mathf.Max(Indicators.healthAmount - amount, 0);
        if (Indicators.healthAmount <= 0)
        {
            OnDeath();
        }
        OnHealthChange();

        yield return new WaitForSeconds(3f); // Затримка на 3 секунди

        // Приховати зображення шкоди
        elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(1 - (elapsedTime / delay)); // Зворотне згладження зникаючого зображення
            Color imageColor = damageImage.color;
            imageColor.a = alpha;
            damageImage.color = imageColor;
            yield return null;
        }

        damageImage.gameObject.SetActive(false);
    }

    private void OnDeath()
    {
        SceneManager.LoadScene(3);
    }
}
