using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace IndicatorsHealth
{
    public class Indicators : MonoBehaviour
    {
        public Image healthBar, foodBar, smileBar;
        public float healthAmount = 100;
        public float foodAmount = 100;
        public float smileAmount = 100;
        public float secondsToEmptyFood = 60f;
        public float secondsToEmptyHealth = 60f;
        public static event Action UpdateHealthE;
        public float secondsToFullSmile = 60f;
        void Start()
        {
            healthBar.fillAmount = 75;
            foodBar.fillAmount = 50;
            smileBar.fillAmount= 30;
        }

        // Update is called once per frame
        void Update()
        {
            if (foodAmount > 0)
                foodAmount -= 100 / secondsToEmptyFood * Time.deltaTime;
            else
                healthAmount -= 100 / secondsToEmptyHealth * Time.deltaTime;
            if(smileAmount < 100)
                smileAmount += 100 / secondsToFullSmile * Time.deltaTime;
            UpdateHealth();
        }
        public void UpdateHealth()
        {
            if (foodAmount > 100)
                foodAmount = 100;
            if (healthAmount > 100)
                healthAmount = 100;
            healthBar.fillAmount = healthAmount / 100;
            foodBar.fillAmount = foodAmount / 100;
            smileBar.fillAmount = smileAmount / 100;
            if (smileAmount >= 100)
                healthAmount = 0;
            else if(smileAmount <= 0)
                smileAmount = -1;
            UpdateHealthE?.Invoke();
        }

    }
}