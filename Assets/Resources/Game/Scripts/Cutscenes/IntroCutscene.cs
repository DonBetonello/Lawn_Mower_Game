using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{

    [SerializeField] private GameObject upgradesMenuButton;
    [SerializeField] private GameObject lawnUpgradeButton;
    [SerializeField] private GameObject upgradesDescription;

    [SerializeField] private GameObject buyUpgradeButton;

    [SerializeField] private DialogWindow dialogWidow;

    [SerializeField] private UpgradeBoardHandler upgradeBoard;
    [SerializeField] private GameObject[] ObjectsToEbable;

    [SerializeField] private IntroDialogSequence introDialogSequence;

   [SerializeField] private AttentionConcentrator attentionConcentrator;

    private bool lawnCreatingAnimationStarted;
    private bool lawnCreatingAnimationEnded;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        StartCoroutine(IntroSequence());
    }

    private IEnumerator IntroSequence()
    {

        yield return StartCoroutine(introDialogSequence.PlayDialogSequnce());

        upgradesMenuButton.SetActive(true);

        attentionConcentrator.gameObject.SetActive(true);

        attentionConcentrator.ConcentrateAttention(upgradesMenuButton);

        Button UpgradesMenuButton = upgradesMenuButton.GetComponent<Button>();
        UpgradesMenuButton.interactable = false;

        yield return StartCoroutine(introDialogSequence.PlayDialogSequnce());

        UpgradesMenuButton.interactable = true;

        yield return new WaitUntil(() => upgradeBoard.IsUpgradeBoardActive == true);

        UpgradesMenuButton.interactable = false;

        attentionConcentrator.returnObjectBack(upgradesMenuButton);

        yield return new WaitForEndOfFrame();

        attentionConcentrator.ConcentrateAttention(lawnUpgradeButton);

        Button LawnUpgradeButton = lawnUpgradeButton.GetComponent<Button>();
        LawnUpgradeButton.interactable = false;

        yield return StartCoroutine(introDialogSequence.PlayDialogSequnce());

        LawnUpgradeButton.interactable = true;

        yield return new WaitUntil(() => upgradesDescription.activeSelf == true);

        Button BuyUpgradeButton = buyUpgradeButton.GetComponent<Button>();
        BuyUpgradeButton.interactable = false;


        attentionConcentrator.returnObjectBack(lawnUpgradeButton);

        attentionConcentrator.ConcentrateAttention(upgradesDescription);

        yield return StartCoroutine(introDialogSequence.PlayDialogSequnce());

        attentionConcentrator.returnObjectBack(upgradesDescription);

        attentionConcentrator.ConcentrateAttention(buyUpgradeButton);

        yield return StartCoroutine(introDialogSequence.PlayDialogSequnce());

        BuyUpgradeButton.interactable = true;

        BuyUpgradeButton.onClick.AddListener(() => lawnCreatingAnimationStarted = true);

        yield return new WaitUntil(()=> lawnCreatingAnimationStarted == true);

        attentionConcentrator.returnObjectBack(buyUpgradeButton);

        attentionConcentrator.gameObject.SetActive(false);

        dialogWidow.gameObject.SetActive(false);
        UpgradesMenuButton.gameObject.SetActive(false);

        UpgradesMenuButton.interactable = true;

         yield return new WaitUntil(() => lawnCreatingAnimationEnded == true);

        dialogWidow.gameObject.SetActive(true);

        yield return StartCoroutine (introDialogSequence.PlayDialogSequnce());

        dialogWidow.gameObject.SetActive(false);
    

        foreach (GameObject obj in ObjectsToEbable)
        {
            obj.SetActive(true);
        }
        UpgradesMenuButton.gameObject.SetActive(true);

        Destroy(gameObject);
    }
    private void LawnCreationEnded()
    {
        lawnCreatingAnimationEnded = true;
    }

    private void OnEnable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneEnded += LawnCreationEnded;
    }
    private void OnDisable()
    {
        GameplayEventBus.OnLawnIncreaseCutsceneEnded -= LawnCreationEnded;
    }

}
