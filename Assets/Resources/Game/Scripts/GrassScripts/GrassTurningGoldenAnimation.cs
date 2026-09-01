using System.Collections;
using UnityEngine;

public class GrassTurningGoldenAnimation : MonoBehaviour
{

   private Material startGrassMaterial;
    [SerializeField] private Material goldenGrassMaterial;
    private Renderer grassRenderer;

 
    [SerializeField]private float grassTurningBackTime = 7;

    private Coroutine normalCoroutine;

    private void OnEnable()
    {
        
        grassRenderer = GetComponentInChildren<Renderer>();
        startGrassMaterial = grassRenderer.sharedMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UFO"))
        {
            BecomeGolden();
        }
    }

    private void BecomeGolden()
    {
        if(normalCoroutine != null) { StopCoroutine(normalCoroutine); }

        grassRenderer.sharedMaterial = goldenGrassMaterial;
        StartCoroutine(BecomeNormal());
    }

    private IEnumerator BecomeNormal()
    {    
        yield return new WaitForSeconds(grassTurningBackTime);
        grassRenderer.sharedMaterial = startGrassMaterial;
        normalCoroutine = null;
    }
    public void ForceBecomeNormal()
    {
        if (normalCoroutine != null) { StopCoroutine(normalCoroutine); }

        grassRenderer.sharedMaterial = startGrassMaterial;
    
    }

}
