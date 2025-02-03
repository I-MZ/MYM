using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplanationManager : MonoBehaviour
{
    public GameObject PlayingText;
    public GameObject MenuText;
    public GameObject SelectText;

    public bool SelectMode;
    bool NowMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            PlayingText.SetActive(false);
            MenuText.SetActive(false);
            SelectText.SetActive(true);
            NowMenu = false;
        }
        else
        {
            PlayingText.SetActive(true);
            MenuText.SetActive(false);
            SelectText.SetActive(false);
            NowMenu = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NowMenu)
        {
            PlayingText.SetActive(false);
            SelectText.SetActive(false);
            MenuText.SetActive(true);
        }
        else
        {
            if (SelectMode)
            {
                SelectText.SetActive(true);
                MenuText.SetActive(false);
            }
            else
            {
                PlayingText.SetActive(true);
                MenuText.SetActive(false);
            }
            
        }
    }

    public void TextChange()
    {
        if (!NowMenu)
            NowMenu = true;
        else
            NowMenu = false;
    }


}
