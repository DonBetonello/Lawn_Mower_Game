using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) { GameplayEventBus.RaiseScreenTouched(); }
    }
}
