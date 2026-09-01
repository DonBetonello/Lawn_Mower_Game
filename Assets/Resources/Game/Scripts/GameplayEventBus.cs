using System;
using UnityEngine;

public static class GameplayEventBus
{
    public static event Action<Grass> OnGrassCut; 
    public static void RaiseGrassCut(Grass grass) { OnGrassCut?.Invoke(grass); }

    public static event Action<Grass> OnGrassRegrew;
    public static void RaiseGrassRegrew(Grass grass) { OnGrassRegrew?.Invoke(grass); }

    public static event Action<float, float, float> OnMultiplyerFlowerPickedUp;
    public static void RaiseMultiplyerFlowerPickedUp(float multiplierLenght, float multiplyer, float respawnTime) { OnMultiplyerFlowerPickedUp?.Invoke(multiplierLenght, multiplyer, respawnTime); }

    public static event Action OnLawnMoverStartedMoving;
    public static void RaiseLawnMoverStartedMoving() { OnLawnMoverStartedMoving?.Invoke(); }

    public static event Action OnLawnMoverStoppedMoving;
    public static void RaiseLawnMoverStoppedMoving() { OnLawnMoverStoppedMoving?.Invoke(); }

    public static event Action OnUFODisappeared;
    public static void RaiseUFODisappeared() {  OnUFODisappeared?.Invoke();}

    public static event Action OnScreenTouched;
    public static void RaiseScreenTouched() { OnScreenTouched?.Invoke(); }

    public static event Action OnLawnIncreaseCutsceneStarted;
    public static void RaiseLawnIncreaseCutsceneStarted()
    {
        OnLawnIncreaseCutsceneStarted?.Invoke();
    }
    public static event Action OnLawnIncreaseCutsceneEnded;
    public static void RaiseLawnIncreaseCutsceneEnded()
    {
        OnLawnIncreaseCutsceneEnded?.Invoke();
    }
}
