using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Sound_Change_Button_Script : MonoBehaviour
{
    public bool is_Sound_On { get => Is_Sound_On; }
    private bool Is_Sound_On = true;
    [SerializeField] Image Sound_Button_Image;
    [SerializeField] Sprite[] Icon_Change_Sprites;
    private int Sound_Icon_Variant = 1;
    public void WhenPressed()
    {

        if (Sound_Icon_Variant == 0)
        {

            Sound_Button_Image.sprite = Icon_Change_Sprites[Sound_Icon_Variant];
            Sound_Icon_Variant = 1;
            Is_Sound_On = true;


        }

        else
        {
            Sound_Button_Image.sprite = Icon_Change_Sprites[Sound_Icon_Variant];
            Sound_Icon_Variant = 0;
            Is_Sound_On = false;
        }




    }
}
