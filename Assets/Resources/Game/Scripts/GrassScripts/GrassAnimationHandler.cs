using UnityEngine;
using DG.Tweening;
public class GrassAnimationHandler : MonoBehaviour
{
    private float GrassCutPosition = -6;
    private float GrassRegrowPosition = -5;

      private GrassParticlesObjectPool particlePool;
    private Vector3 startGrassSize;

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
    }
    private void Awake()
    {
        startGrassSize = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
     
        particlePool = FindFirstObjectByType<GrassParticlesObjectPool>();
    }
    private void RandomizeGrassRotationAtEnable()
    {
        transform.DORotate(new Vector3(0, Random.Range(0, 360), 0), 0);      
    }
    public void OnGrassCut(Grass grass)
    {
        if (grass != GetComponent<Grass>()) { return; }

        var tweenSequnce = DOTween.Sequence();
        GameObject grassObject = grass.gameObject;
        var grassCollider = grassObject.GetComponent<BoxCollider>();
        Vector3 newPosition = new Vector3(grassObject.transform.position.x, GrassCutPosition, grassObject.transform.position.z);

        DOTween.SetTweensCapacity(1250, 312);

        var particle = particlePool.GetParticle();

        tweenSequnce.AppendCallback(() => grassCollider.enabled = false) //Disable collider to prevent bugs
            .AppendCallback(() => particle.transform.position = grassObject.transform.position) //Spawn grass particle
            .Append(grassObject.transform.DOMove(newPosition, 1)) //Move grass to bottom position
            .Join(grassObject.transform.DORotate(new Vector3(0, Random.Range(0, 360), 0), 0.5f)) 
            .Join(grassObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear)); 

    }
    public void OnGrassRegrew(Grass grass)
    {
        if (grass != GetComponent<Grass>()) { return; }

        var tweenSequnce = DOTween.Sequence();
        var grassObject = grass.gameObject;
        var grassCollider = grassObject.GetComponent<BoxCollider>();
        Vector3 newPosition = new Vector3(grassObject.transform.position.x, GrassRegrowPosition, grassObject.transform.position.z);

        tweenSequnce
            .Append(grassObject.transform.DOMove(newPosition, 1)) //Get grass to top position
            .Join(grassObject.transform.DOScale(new Vector3(startGrassSize.x *1.1f, startGrassSize.y *1.1f, startGrassSize.z * 1.1f), 1).SetEase(Ease.Linear))
            .Join(grassObject.transform.DORotate(new Vector3(0, Random.Range(0, 360), 0), 1f))
            .Append(grassObject.transform.DOScale(startGrassSize, 0.1f).SetEase(Ease.Linear))
        .AppendCallback(() => grassCollider.enabled = true); //Re-enable collider 
    }
}
