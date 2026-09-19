using UnityEngine;

public class PlayButtonClickedSound : MonoBehaviour
{
    [SerializeField]private AudioSource ClickSound;
    private void OnEnable()
    {
        SoundEventBus.OnButtonClicked += PlaySound;
    }
    private void OnDisable()
    {
        SoundEventBus.OnButtonClicked -= PlaySound;
    }

    private void PlaySound()
    {
        ClickSound.Play();
    }
}
