
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
 
    private bool PauseButtonOn = false;

    public void OnPauseButtonClick()
    {
     //  SetGameOnPause(!PauseButtonOn);
      //  Debug.Log("Is game on pause?" +  PauseButtonOn);
    }
 /*
    private void SetGameOnPause(bool isPaused) {

        PauseButtonOn = isPaused;
        if(isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;


    }*/
}
