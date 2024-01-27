using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public Slider sliderStamina;
    public Text currentText;
    public float currentStamina;
    public float maxStamina;
    public float minStamina;

    public bool isOnEmergency = false;

    private void Start()
    {
        sliderStamina.maxValue = maxStamina;
        sliderStamina.minValue = minStamina;    

        currentStamina = maxStamina;
    }
    private void Update()
    {
        sliderStamina.value = currentStamina;
        currentText.GetComponent<Text>().text = string.Format("{0:0}%", currentStamina);

        StaminaChecked();
        StaminaKeys();
    }

    private void StaminaChecked()
    {
        if(currentStamina < minStamina)
            currentStamina = minStamina;

        if(currentStamina > maxStamina)
            currentStamina = maxStamina;
    }

    private void StaminaKeys()
    {
        if (isOnEmergency)
            return;
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
                currentStamina -= Time.deltaTime * 8f;
            else
                currentStamina += Time.deltaTime * 2f;
        }
        else
            currentStamina += Time.deltaTime * 4f;
        
    }
}
