using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Image healthBarSprite;
    [SerializeField]private Image bloodSplatter = null;

    public CombatManager combatManager;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void ShowBloodSplatter()
    {
        Color bloodSplatterAlpha = bloodSplatter.color;
        bloodSplatterAlpha.a = 1;
        bloodSplatter.color = bloodSplatterAlpha;
    }
}
