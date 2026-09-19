using UnityEngine;
using UnityEngine.UI;

public class ChangePageButton : MonoBehaviour
{
    [SerializeField] private ChangeUpgradePage changeUpgradePage;
    [SerializeField] private bool isNextPageButton;

    private Button button;
    private Vector3 startScale;

    private void Awake()
    {
        startScale = gameObject.transform.localScale;
        button = GetComponent<Button>();
    
        ManageButtonActive();
    }

    public void OnClick(bool nextPage)
    {
        changeUpgradePage.ChangePage(nextPage);
        SoundEventBus.RaiseButtonClicked();
    }

    public void ManageButtonActive()
    {
        bool shouldBeVisible = isNextPageButton
            ? changeUpgradePage.CurrentPage < changeUpgradePage.PagesCount - 1
            : changeUpgradePage.CurrentPage > 0;

        transform.localScale = shouldBeVisible
            ? startScale
            : Vector3.zero;

        button.interactable = shouldBeVisible;
    }
}
