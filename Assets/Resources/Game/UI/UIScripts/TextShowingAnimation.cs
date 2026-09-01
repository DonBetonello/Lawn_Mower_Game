using System.Collections;
using TMPro;
using UnityEngine;

public class TextShowingAnimation : MonoBehaviour
{
    private Coroutine currentCoroutine;

    public bool isTextShowingSequenceCurrentlyRunning { get; private set; }
    public bool isTextFullyDisplayed { get; private set; }

    public void PlayTextAnimation(TextMeshProUGUI textObject, string text)
    {
        currentCoroutine = StartCoroutine(PlayTextShowingSequence(textObject,text));
    }
    public void SkipTextAnimation(TextMeshProUGUI textObject, string text)
    {
        StopCoroutine(currentCoroutine);
        textObject.text = text;
        isTextFullyDisplayed = true;
        isTextShowingSequenceCurrentlyRunning = false;
    }
    private IEnumerator PlayTextShowingSequence (TextMeshProUGUI textObject, string text)
    {
        isTextShowingSequenceCurrentlyRunning = true;
        isTextFullyDisplayed =false;
        var newText = text;
        newText.ToCharArray();
        textObject.text = "";

        foreach (char c in newText) {
            textObject.text += c;
            yield return new WaitForSeconds(0.05f);

        }
        isTextFullyDisplayed = true;
        isTextShowingSequenceCurrentlyRunning = false;

    }

}
