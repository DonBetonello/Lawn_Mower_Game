using DG.Tweening;
using UnityEngine;

public class GrassCuttingHandler : MonoBehaviour
{
    private float GrassRegrowTimer = 0;

    [Tooltip("Add any layer thet should PREVENT grass from growing if placed above")]
    [SerializeField] private LayerMask blockingLayers;
    [SerializeField]private Grass grass;


    private bool isCut = false;


    void Update()
    {
        if (!isCut) return;

        GrassRegrowTimer += Time.deltaTime;

        if (IsReadyToGrow())
        {
            RegrowGrass();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.transform.CompareTag("LawnMover") || collision.gameObject.transform.CompareTag("Drone")) { CutGrass(); }     
    }

    public void CutGrass()
    {
        isCut = true;
        GrassRegrowTimer = 0;
  
        GameplayEventBus.RaiseGrassCut(grass);
    }

    public void RegrowGrass()
    {
        grass.ManageGrassGolden(false);
     
        isCut = false;
        GrassRegrowTimer = 0;

        GameplayEventBus.RaiseGrassRegrew(grass);
    }
   
    public bool IsReadyToGrow()
    {
        if (Physics.CheckSphere(new Vector3(grass.transform.position.x, grass.transform.position.y + 2, grass.transform.position.z), 0.5f, blockingLayers)) { return false; } 

        return GrassRegrowTimer >= grass.RegrowTime;
    }
    public void ForceRegrow()
    {
        RegrowGrass();
    }
}