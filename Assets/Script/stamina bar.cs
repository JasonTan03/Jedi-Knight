using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminabar : MonoBehaviour
{
    public float stamina;
    float maxStamina;

    public Slider staminaBar;
    public float regenerate;

    public playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina != maxStamina && player.isalive == true)
        {
            IncreaseStamina();
        }
        staminaBar.value = stamina;
    }
    public void DecreaseStamina(float decrease)
    {
        if (stamina != 0)
        {
            if (stamina != 0)
                stamina -= decrease;
            if (stamina <= -1)
                stamina = 0;
        }
    }
    public void IncreaseStamina()
    {
        stamina += regenerate * Time.deltaTime;
        if (stamina >= maxStamina)
            stamina = maxStamina;
    }
}
