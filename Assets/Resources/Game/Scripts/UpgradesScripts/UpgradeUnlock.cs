using System.Collections.Generic;
using UnityEngine;

public class UpgradeUnlock : MonoBehaviour
{
    private HashSet<string> unlockedUpgrades = new HashSet<string>();

    public bool CanUnlock(UpgradeData upgradeData)
    {   
        foreach (var req in upgradeData.requiredUpgrades)
        {
            if (!unlockedUpgrades.Contains(req.upgradeID))
                return false;
        }
        return true;
    }

    public void Unlock(UpgradeData upgradeData)
    {
        if (CanUnlock(upgradeData))
        {
            unlockedUpgrades.Add(upgradeData.upgradeID);  
        }
        else { return; }
    }
}
