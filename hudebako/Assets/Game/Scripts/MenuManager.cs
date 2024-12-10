using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance = null;

    public GameObject Menu;
    public GameObject TutorialPage1;
    public GameObject TutorialPage2;

    public GameObject button1;
    public int b1level;
    public GameObject button2;
    public int b2level;
    public GameObject button3;
    public int b3level;
    public GameObject button4;
    public int b4level;
    public GameObject button5;
    public int b5level;
    public GameObject button6;
    public int b6level;
    public GameObject button7;
    public int b7level;
    public GameObject button8;
    public int b8level;

    public GameObject nextbutton;

    private int page;
    public bool checkmenu;

    [Header("Œˆ’èŽž‚É–Â‚ç‚·SE")]       public AudioClip KETTEI;
    [Header("ƒLƒƒƒ“ƒZƒ‹Žž‚É–Â‚ç‚·SE")] public AudioClip KYANSERU;

    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<MenuManager>();

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        button7.SetActive(false);
        button8.SetActive(false);
        nextbutton.SetActive(false);
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ReturnMenu();
                TutorialPage1.SetActive(false);
                TutorialPage2.SetActive(false);
            }
        }
        else
        {
            TutorialPage1.SetActive(false);
            TutorialPage2.SetActive(false);
        }

        if (StageClearManager.clearlevel >= b1level)
        {
            button1.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b2level)
        {
            button2.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b3level)
        {
            button3.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b4level)
        {
            button4.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b5level)
        {
            button5.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b6level)
        {
            button6.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b7level)
        {
            button7.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b8level)
        {
            button8.SetActive(true);
        }
        if (StageClearManager.clearlevel >= b5level)
        {
            nextbutton.SetActive(true);
        }

    }

    public void NextPage()
    {
        page++;
        GameManager.instance.PlaySE(KETTEI);
    }

    public void BackPage()
    {
        page--;
        GameManager.instance.PlaySE(KETTEI);
    }

    public void GoTutorial()
    {
        Menu.SetActive(false);
        checkmenu = true;
        page = 1;
        GameManager.instance.PlaySE(KETTEI);
    }

    public void ReturnMenu()
    {
        Menu.SetActive(true);
        checkmenu = false;
        GameManager.instance.PlaySE(KYANSERU);
    }
}
