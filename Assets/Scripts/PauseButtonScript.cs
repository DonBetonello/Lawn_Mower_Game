using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class PauseButtonScript : MonoBehaviour
{
    [SerializeField] private Image Shop_Menu_Background;
    [SerializeField] private Button SpeedButton;
    [SerializeField] private Button MoneyButton;
    [SerializeField] private Button GrowButton;
    [SerializeField] private Button DroneBuyButton;
    [SerializeField] private Button Drone_Upgrade_Speed_Button;
    [SerializeField] private GameObject JoyStick;
    [SerializeField] private AudioSource ButtonSound;
    [SerializeField] private Sound_Change_Button_Script Is_Sound_On;
    private bool PauseButtonOn = false;
    public DroneUpgrade DroneIsBought;
    // Start is called before the first frame update
    void Start()
    {
        PauseButtonOn = false;
    }

    public void FixedUpdate()
    {

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

        TimeScale();
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
    void TimeScale()
    {
        Time.timeScale = 0f;
    }
}
