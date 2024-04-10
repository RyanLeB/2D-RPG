using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponQuest : Quest
{
    public int requiredWeaponCount = 1;
    
    public override bool CheckCompletionCondition(PlayerController player)
    {
        // Get the Inventory from the scene
        Inventory inventory = FindObjectOfType<Inventory>();

        // Check if the inventory is null
        if (inventory == null)
        {
            Debug.LogError("Inventory not found in the scene.");
            return false;
        }

        // Check if the player has collected enough potions
        return inventory.CountWeapons() >= requiredWeaponCount;
    }


}

