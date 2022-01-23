using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePagesManager : MonoBehaviour
{
    [SerializeField]
    private List<PausePageAnimations> pages;
    private int activePage;
    private int previousPage;


    // Start is called before the first frame update
    void Start()
    {
        activePage = -1;
        previousPage = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i].isSelected)
            {
                pages[i].isSelected = false;
                activePage = i;
                ChangePage();
            }
        }
        
        

    }

    void ChangePage()
    {
        if (activePage == previousPage && pages[previousPage].State == pageState.idle) //page is being closed
        {
            for (int i = 0; i < pages.Count; i++) pages[i].State = pageState.idle;
        }
        else
        {
            for (int i = 0; i < pages.Count; i++)
            {
                if (i <= activePage) //page above active one
                {
                    pages[i].State = pageState.active;
                }
                if (i > activePage) //page below active one
                {
                    pages[i].State = pageState.standBy;
                }
            }
        }
        previousPage = activePage;
    }

}
