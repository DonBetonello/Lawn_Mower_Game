
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    [SerializeField] private Image Shop_Menu_Background;
    [SerializeField] private GameObject JoyStick;
    [SerializeField] private AudioSource ButtonSound;
    [SerializeField] private Sound_Change_Button_Script Is_Sound_On;
    private bool PauseButtonOn = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseButtonOn = false;
    }

    public void OnPauseButtonClick()
    {
        if (PauseButtonOn == false)
        {
            PauseGameOn();

        }
        else
        {
            PauseGameOff();
        }
    }
    public void PauseGameOn()
    {
        //ButtonsOnScreen                   
        JoyStick.gameObject.SetActive(false);
        Shop_Menu_Background.gameObject.SetActive(true);
        PauseButtonOn = true;
        GetComponent<AudioSource>();
        if (Is_Sound_On.is_Sound_On == true)
        {
            ButtonSound.Play();
        }

        Time.timeScale = 0f;
    }
    public void PauseGameOff()
    {
        //ButtonsOffScreen
        JoyStick.gameObject.SetActive(true);
        Shop_Menu_Background.gameObject.SetActive(false);
        if (Is_Sound_On.is_Sound_On == true)
        {
            ButtonSound.Play();
        }


        PauseButtonOn = false;
        Time.timeScale = 1f;
    }
  
}
