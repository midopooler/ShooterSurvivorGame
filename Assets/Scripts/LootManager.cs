using UnityEngine;

public class LootManager : MonoBehaviour
{
    public GameObject[] lootItems;
    public float dropChance = 0.5f; // 50% chance to drop loot

    public void DropLoot(Vector2 position)
    {
        if (Random.value <= dropChance)
        {
            int lootIndex = Random.Range(0, lootItems.Length);
            Instantiate(lootItems[lootIndex], position, Quaternion.identity);
        }
    }
}