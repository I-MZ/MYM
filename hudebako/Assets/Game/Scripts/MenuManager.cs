using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Menu;
    public GameObject TutorialPage1;
    public GameObject TutorialPage2;

    private int page;
    public bool checkmenu;

    // Start is called before the first frame update
    void Start()
    {
        TutorialPage1.SetActive(false);
        TutorialPage2.SetActive(false);
        page = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (checkmenu)
        {
            switch (page)
            {
                case 1:
                    TutorialPage1.SetActive(true);
                    TutorialPage2.SetActive(false);
                    break;
                case 2:
                    TutorialPage1.SetActive(false);
                    TutorialPage2.SetActive(true);
                    break;
            }
        }
        else
        {
            TutorialPage1.SetActive(false);
            TutorialPage2.SetActive(false);
        }
        
    }

    public void NextPage()
    {
        page++;
    }

    public void BackPage()
    {
        page--;
    }

    public void GoTutorial()
    {
        Menu.SetActive(false);
        checkmenu = true;
        page = 1;
    }

    public void ReturnMenu()
    {
        Menu.SetActive(true);
        checkmenu = false;
    }
}
