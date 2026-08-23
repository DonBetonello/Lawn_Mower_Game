using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUpgradePage : MonoBehaviour
{


    [SerializeField]private int currentPage = 0;
    [SerializeField] private List<GameObject> pages = new();

    [SerializeField] private ChangePageButton nextPageButton;
    [SerializeField] private ChangePageButton PreviousPageButton;

    [SerializeField] private GameObject upgradeDescription;

    public int PagesCount => pages.Count;
    public int CurrentPage => currentPage;
 

    public void ShowPage(int page)
    {
        pages[currentPage].SetActive(false);

        pages[page].SetActive(true);

        currentPage = page;

        UIEventBus.RaisePageChanged();
        UIEventBus.RaiseUpgradeDescriptionClosed(upgradeDescription);
        
    }

    public void ChangePage(bool nextPage)
    {
        if (nextPage) { ShowPage(currentPage + 1);  }
        else { ShowPage(currentPage - 1); }

        nextPageButton.ManageButtonActive();
        PreviousPageButton.ManageButtonActive();

    }
}
