using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Menu;
    public GameObject tutorial;
    private MenuManager mm;
    public GameObject button;
    public int buttonlevel;

    [Header("Œˆ’èŽž‚É–Â‚ç‚·SE")] public AudioClip KETTEI;
    [Header("ƒLƒƒƒ“ƒZƒ‹Žž‚É–Â‚ç‚·SE")] public AudioClip KYANSERU;

    // Start is called before the first frame update
    void Start()
    {
        mm = Menu.GetComponent<MenuManager>();
        tutorial.SetActive(false);
        button.SetActive(false);
    }

    private void Update()
    {
        if (StageClearManager.clearlevel >= buttonlevel)
        {
            button.SetActive(true);
        }
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
