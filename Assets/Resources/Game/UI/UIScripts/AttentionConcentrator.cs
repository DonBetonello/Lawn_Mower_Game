using UnityEngine;

public class AttentionConcentrator : MonoBehaviour
{
    private Transform previousParent;

   public void ConcentrateAttention(GameObject objectToConcentrateAttentionOn)
    {
        previousParent = objectToConcentrateAttentionOn.transform.parent;

        objectToConcentrateAttentionOn.transform.SetParent(gameObject.transform);

    }
        

    public void returnObjectBack(GameObject objectToConcentrateAttentionOn)
    {
        if (previousParent != null) {
        objectToConcentrateAttentionOn.transform.SetParent(previousParent);
        }
    } 
}
