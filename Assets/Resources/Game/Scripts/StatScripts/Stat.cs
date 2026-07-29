using System.Collections.Generic;
using UnityEngine;

public class Stat :MonoBehaviour
{
    private Dictionary<StatType, float> stats = new();

    public float GetStat(StatType type)
    {
        return stats.TryGetValue(type, out var value) ? value : 0;
    }

    public void AddStat(StatType type, float value)
    {
        if (!stats.ContainsKey(type))
            stats[type] = 0;

        stats[type] = value;
        
    }
}
