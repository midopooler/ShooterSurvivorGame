using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public int experience = 0;
    public int level = 1;

    public void GainExperience(int amount)
    {
        experience += amount;
        if (experience >= GetExperienceThreshold())
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        experience = 0;

        // Randomly choose an upgrade
        int upgradeChoice = Random.Range(0, 4);
        switch (upgradeChoice)
        {
            case 0:
                // Increase Shoot Rate
                break;
            case 1:
                // Increase Max Health
                break;
            case 2:
                // Increase Move Speed
                break;
            case 3:
                // Poisoned bullets
                break;
        }

        // Display upgrade message on screen
    }

    int GetExperienceThreshold()
    {
        return level * 10; // Example: each level requires 10 experience points
    }
}