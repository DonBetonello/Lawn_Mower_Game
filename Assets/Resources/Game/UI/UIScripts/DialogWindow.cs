using System.Collections;
using TMPro;
using UnityEngine;

public class DialogWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private RectTransform canvas;

    [SerializeField] private TextShowingAnimation textShowingAnimationHandler;

    private bool buttonClicked;

    private bool firstDialogLine;

    private int dialogLineCounter = 0;

    public IEnumerator DialogSequnce(string[] dialogLines)
    {
        firstDialogLine = true;
        dialogLineCounter = 0;
        while (dialogLineCounter <= dialogLines.Length - 1)
        {

            if (textShowingAnimationHandler.isTextFullyDisplayed && buttonClicked || firstDialogLine == true)
            {

                textShowingAnimationHandler.PlayTextAnimation(dialogText, dialogLines[dialogLineCounter]);

                buttonClicked = false;
                firstDialogLine = false;
            }
            else if (textShowingAnimationHandler.isTextShowingSequenceCurrentlyRunning && buttonClicked)
            {
                textShowingAnimationHandler.SkipTextAnimation(dialogText, dialogLines[dialogLineCounter]);

                buttonClicked = false;
            }

            yield return null;
        }
        dialogLineCounter = 0;
    }

    private void ChangeToNextDialog()
    {
        
        if (textShowingAnimationHandler.isTextFullyDisplayed) { dialogLineCounter++; }
        buttonClicked = true;
    }

    private void OnEnable()
    {
        GameplayEventBus.OnScreenTouched += ChangeToNextDialog;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnScreenTouched -= ChangeToNextDialog;
    }
}

