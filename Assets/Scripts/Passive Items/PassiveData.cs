using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Passive Data", menuName = "2D Top-down Rogue-like/Passive Data")]
public class PassiveData : ItemData
{
    public Passive.Modifier baseStats;
    public Passive.Modifier[] growth;

    public Passive.Modifier GetLevelData(int level)
    {
        if (level - 2 < growth.Length)
        {
            return growth[level - 2];
        }

        Debug.LogWarning(string.Format("Passive doesn't have its level up stats configured for Level {0}!", level));
        return new Passive.Modifier();
    }
}
