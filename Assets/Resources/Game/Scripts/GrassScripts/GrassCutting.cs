using DG.Tweening;
using UnityEngine;

public class GrassCuttingHandler : MonoBehaviour
{
    private float GrassRegrowTimer = 0;

    [Tooltip("Add any layer thet should PREVENT grass from growing if placed above")]
    [SerializeField] private LayerMask blockingLayers;
    private Grass grass;
    private bool isCut = false;

    void Start()
    {
        grass = GetComponent<Grass>();
    }

    void Update()
    {
        if (!isCut) return;

        GrassRegrowTimer += Time.deltaTime;

        if (isReadyToGrow())
        {
            RegrowGrass();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        CutGrass();
    }

  

    public void CutGrass()
    {

        isCut = true;
        GrassRegrowTimer = 0;

        GameplayEventBus.RaiseGrassCut(grass);
    }

    public void RegrowGrass()
    {
        isCut = false;
        GrassRegrowTimer = 0;

        GameplayEventBus.RaisedGrassRegrew(grass);
    }
   
    public bool isReadyToGrow()
    {
        if (Physics.CheckSphere(new Vector3(grass.transform.position.x, grass.transform.position.y + 2, grass.transform.position.z), 0.5f, blockingLayers)) { return false; } 

        return GrassRegrowTimer >= grass.GetRuntimeData().CurrentRegrowTime;
    }
}