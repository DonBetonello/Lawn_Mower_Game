using UnityEngine;
using DG.Tweening;
public class GrassAnimationHandler : MonoBehaviour
{
    readonly private float GrassCutPosition = -6;
    readonly private float GrassRegrowPosition = -5;

    private GrassParticlesObjectPool particlePool;
    private Vector3 startGrassSize;

    private Sequence currentAnimation;

    private void Awake()
    {
        startGrassSize = transform.localScale;

        particlePool = FindFirstObjectByType<GrassParticlesObjectPool>();

        DOTween.SetTweensCapacity(1250, 500);
    }

    private void OnEnable()
    {
        RandomizeGrassRotationAtEnable();

        GameplayEventBus.OnGrassCut += OnGrassCut;
        GameplayEventBus.OnGrassRegrew += OnGrassRegrew;
    }

    private void OnDisable()
    {
        GameplayEventBus.OnGrassCut -= OnGrassCut;
        GameplayEventBus.OnGrassRegrew -= OnGrassRegrew;

        StopAnimation();
    }

    private void RandomizeGrassRotationAtEnable()
    {
        transform.DORotate(
            new Vector3(0, Random.Range(0, 360), 0),
            0
        );
    }


    private void OnGrassCut(Grass grass)
    {
        if (grass != GetComponent<Grass>())
            return;

        StopAnimation();

        var grassCollider = grass.GetComponent<BoxCollider>();

        Vector3 newPosition = new Vector3(
            transform.position.x,
            GrassCutPosition,
            transform.position.z
        );

        var particle = particlePool.GetParticle();

        currentAnimation = DOTween.Sequence();

        currentAnimation
            .AppendCallback(() => grassCollider.enabled = false)
            .AppendCallback(() =>
            {
                particle.transform.position = transform.position;
            })
            .Append(transform.DOMove(newPosition, 1f))
            .Join(transform.DORotate(new Vector3(0, Random.Range(0, 360), 0),0.5f))
            .Join(transform.DOScale(Vector3.zero,0.5f).SetEase(Ease.Linear));
    }


    private void OnGrassRegrew(Grass grass)
    {
        if (grass != GetComponent<Grass>())
            return;

        StopAnimation();

        var grassCollider = grass.GetComponent<BoxCollider>();

        Vector3 newPosition = new Vector3(
            transform.position.x,
            GrassRegrowPosition,
            transform.position.z
        );

        currentAnimation = DOTween.Sequence();

        currentAnimation
            .Append(transform.DOMove(newPosition,1f))
            .Join(transform.DOScale(startGrassSize * 1.1f,1f).SetEase(Ease.Linear))
            .Join(transform.DORotate(new Vector3(0, Random.Range(0, 360), 0),1f))
            .Append(transform.DOScale(startGrassSize,0.1f).SetEase(Ease.Linear))
            .AppendCallback(() =>
            {
                grassCollider.enabled = true;
            });
    }


    public void PlayOnEnableAnimation()
    {
        StopAnimation();

        var renderer = GetComponentInChildren<Renderer>();

        renderer.enabled = true;

        transform.localScale = Vector3.zero;

        transform.DOScale(
            startGrassSize,
            0.3f
        ).SetEase(Ease.OutBack);
    }


    public void StopAnimation()
    {
        currentAnimation?.Kill();
        currentAnimation = null;

        transform.DOKill();
    }
}