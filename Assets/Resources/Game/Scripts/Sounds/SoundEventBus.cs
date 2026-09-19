using System;
using UnityEngine;

public static class SoundEventBus  
{
    
    public static event Action OnButtonClicked;
    public static void RaiseButtonClicked()
    {
        OnButtonClicked?.Invoke();
    }
}
