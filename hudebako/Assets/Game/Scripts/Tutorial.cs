using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Menu;
    public GameObject tutorial;
    private MenuManager mm;

    [Header("決定時に鳴らすSE")] public AudioClip KETTEI;
    [Header("キャンセル時に鳴らすSE")] public AudioClip KYANSERU;

    // Start is called before the first frame update
    void Start()
    {
        mm = Menu.GetComponent<MenuManager>();
        tutorial.SetActive(false);
    }

    public void GoTutorial()
    {
        tutorial.SetActive(true);
        mm.checkmenu = false;
        GameManager.instance.PlaySE(KETTEI);
    }


    public void BackList()
    {
        tutorial.SetActive(false);
        mm.checkmenu = true;
        GameManager.instance.PlaySE(KYANSERU);
    
    }
}
