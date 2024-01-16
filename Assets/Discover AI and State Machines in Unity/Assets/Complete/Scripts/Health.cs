using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int maxHealth;
    private int currentHealth;
    [SerializeField]
    private Slider healthbar;
    [SerializeField]
    private string deathSceneName;
    [SerializeField]
    private Image damageImage; // Посилання на зображення для відображення шкоди
    [SerializeField]
    private AnimationCurve fadeCurve; // AnimationCurve для згладження зникнення зображення шкоди

    void Start()
    {
        // Ініціалізація
    }

    public void SetHealth(int amount)
    {
        currentHealth = maxHealth = amount;
        OnHealthChange();
    }

    void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChange();
    }

    void OnHealthChange()
    {
        healthbar.value = (float)currentHealth / (float)maxHealth;
    }

    public IEnumerator TakeDamageDelayed(int amount, float delay)
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

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        if (currentHealth == 0)
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
