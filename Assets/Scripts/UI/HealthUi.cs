using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private PlayerHealth playerHealth;

    void OnEnable()
    {
        playerHealth.onHealthChanged.AddListener(UpdateHealthUi);
    }

    void OnDisable()
    {
        playerHealth.onHealthChanged.RemoveListener(UpdateHealthUi);       
    }

    void UpdateHealthUi(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
        healthText.text = $"{health:F2}";
    }
}
