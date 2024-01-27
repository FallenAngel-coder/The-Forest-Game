using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace IndicatorsHealth
{
    public class Indicators : MonoBehaviour
    {
        public Image healthBar, foodBar, smileBar;
        public float healthAmount = 100;
        public float foodAmount = 100;

        public float secondsToEmptyFood = 60f;
        public float secondsToEmptyHealth = 60f;
        void Start()
        {
            healthBar.fillAmount = healthAmount / 100;
            foodBar.fillAmount = foodAmount / 100;
        }

        // Update is called once per frame
        void Update()
        {
            if (foodAmount > 0)
            {
                foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
                foodBar.fillAmount = foodAmount / 100;
            }
            else
            {
                healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
            }
            UpdateHealth();
        }
        public void UpdateHealth()
        {
            healthBar.fillAmount = healthAmount / 100;
        }
    }
}