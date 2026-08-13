using UnityEngine;

public class BootStrap : MonoBehaviour
{



    private void Awake()
    {
      DontDestroyOnLoad(this);
    }


}
