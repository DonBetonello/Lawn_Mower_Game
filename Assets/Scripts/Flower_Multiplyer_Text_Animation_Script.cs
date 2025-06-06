using UnityEngine;
using DG.Tweening;

public class Flower_Multiplyer_Text_Animation_Script : MonoBehaviour
{
    private void OnEnable()
    {      
        transform.DOScale(1.5f, 0.3f);
        transform.DORotate(new Vector3(0, 0, -100), 1);
        transform.DOScale(1f, 0.3f);
        transform.DORotate(new Vector3(0, 0, 0), 1);
    }
}
