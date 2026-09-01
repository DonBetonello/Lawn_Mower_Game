using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class IntroDialogSequence : MonoBehaviour
{

    [SerializeField] private DialogWindow dialogWindow;
    private int partCounter = 0;

    [SerializeField] private List<DialogScriptableData> sciptableDatas = new List<DialogScriptableData>();

    public void Play()
    {

    }


    public IEnumerator PlayDialogSequnce()
    {
        if (partCounter <= sciptableDatas.Count)
        {
            yield return StartCoroutine(dialogWindow.DialogSequnce(sciptableDatas[partCounter].Lines));
            partCounter++;  
        }
        yield return null;
    }
}
