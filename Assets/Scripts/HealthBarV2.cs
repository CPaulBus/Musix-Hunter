using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarV2 : MonoBehaviour
{
    private Image _healthBar;
    private float _CurrHealth;
    private float _maxHealth;
    [SerializeField] private PlayerHealthSO _playerHealth;

    private void Start()
    {
        _healthBar = GetComponent<Image>();
        _maxHealth = _playerHealth.GetHealth();
    }

    public void SetHealthBar()
    {
        _CurrHealth = _playerHealth.GetHealth();
        _healthBar.fillAmount = _CurrHealth / _maxHealth;
    }
}
