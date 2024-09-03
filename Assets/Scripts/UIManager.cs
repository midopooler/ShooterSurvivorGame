using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Slider experienceBar;
    public Text ammoIndicator;
    public Text killsCounter;
    public GameObject deathScreen;

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthBar.value = (float)currentHealth / maxHealth;
    }

    public void UpdateExperienceBar(int currentExperience, int experienceThreshold)
    {
        experienceBar.value = (float)currentExperience / experienceThreshold;
    }

    public void UpdateAmmoIndicator(int currentAmmo, int maxAmmo)
    {
        ammoIndicator.text = $"{currentAmmo}/{maxAmmo}";
    }

    public void UpdateKillsCounter(int kills)
    {
        killsCounter.text = $"Kills: {kills}";
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}