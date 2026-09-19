using UnityEngine;

public class GrassSounds : MonoBehaviour
{
    [SerializeField] private AudioSource regrewSound;
    private float nextGrassSoundTime;
    [SerializeField] private float grassSoundCooldown = 0.08f;
    private bool isCutscenePlaying = false;

    private void OnEnable()
    {
        GameplayEventBus.OnGrassRegrew += PlayRegrewSound;
        GameplayEventBus.OnGrassCut += PlayGrassCutSound;
        GameplayEventBus.OnLawnIncreaseCutsceneStarted += ChangeCutscenePlaying;
        GameplayEventBus.OnLawnIncreaseCutsceneEnded += ChangeCutscenePlaying;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnGrassRegrew -= PlayRegrewSound;
        GameplayEventBus.OnGrassCut -= PlayGrassCutSound;
        GameplayEventBus.OnLawnIncreaseCutsceneStarted -= ChangeCutscenePlaying;
        GameplayEventBus.OnLawnIncreaseCutsceneEnded -= ChangeCutscenePlaying;
    }

    private void PlayRegrewSound(Grass grass)
    {
        if (isCutscenePlaying)
            return;

        if (Time.time < nextGrassSoundTime)
            return;

        nextGrassSoundTime = Time.time + grassSoundCooldown;

        regrewSound.PlayOneShot(regrewSound.clip);

    }
    private void PlayGrassCutSound(Grass grass)
    {

    }
    private void ChangeCutscenePlaying()
    {
        isCutscenePlaying = !isCutscenePlaying;
    }
}
