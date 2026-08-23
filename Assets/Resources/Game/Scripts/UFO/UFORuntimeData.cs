using UnityEngine;

public class UFORuntimeData
{
    private float uFOSize;
    private float respawnTime;
    private float goldenMultiplier;

    public float UFOSize => uFOSize;
    public float RespawnTime => RespawnTime;
    public float GoldenMultiplier => goldenMultiplier;


    public UFORuntimeData(float startSize, float startRespawnTime, float startGoldenMultiplier)
    {
        uFOSize = startSize;
        respawnTime = startRespawnTime;
        goldenMultiplier = startGoldenMultiplier;
    }
    public void Upgrade(StatType type, float newValue)
    {
        switch (type)
        {
            case StatType.UFOSize:
                uFOSize = newValue;
                break;

            case StatType.UFORespawnTime:
                respawnTime = newValue;
                break;

            case StatType.UFOGoldenMultiplier:
                goldenMultiplier = newValue;
                break;
        }

    }
}

