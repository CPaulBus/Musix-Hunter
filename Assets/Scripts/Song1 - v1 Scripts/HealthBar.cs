using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float CurrHealth;
    private float maxHealth = 100f;

    private void Start()
    {
        healthBar = GetComponent<Image>();
    }

    private void Update()
    {
        CurrHealth = PlayerHealth.instance.GetHealth();
        healthBar.fillAmount = CurrHealth / maxHealth;
    }
}
