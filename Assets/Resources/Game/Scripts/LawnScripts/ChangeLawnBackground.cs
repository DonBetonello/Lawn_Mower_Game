using Unity.VisualScripting;
using UnityEngine;

public class ChangeLawnBackground : MonoBehaviour
{
    [SerializeField] private GameObject[] LawnBackgrounds;
    private int currentBackground = 0;

    public void ChangeBackground()
    {
   
        LawnBackgrounds[currentBackground].SetActive(false);
        int newBackgound = currentBackground+1;
        LawnBackgrounds[newBackgound].SetActive(true);
        currentBackground++;
    }
}
