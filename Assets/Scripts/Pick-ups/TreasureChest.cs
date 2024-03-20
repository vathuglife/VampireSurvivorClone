using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreasureChest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerInventory p = col.GetComponent<PlayerInventory>();
        if (p)
        {
            bool randomBool = Random.Range(0,2) == 0;
            
        }
    }

    public void OpenTreasureChest(PlayerInventory inventory, bool isHigherTier)
    {
        foreach (PlayerInventory.Slot s in inventory.weaponSlots) 
        { 
            Weapon w = s.item as Weapon;
            if (w.data.evolutionData == null) continue;

            foreach (ItemData.Evolution e in w.data.evolutionData)
            {
                if (e.condition == ItemData.Evolution.Condition.treasureChest)
                {
                    bool attempt = w.AttemptEvolution(e, 0);
                    if (attempt) return;
                }
            }
        }
    }
}
