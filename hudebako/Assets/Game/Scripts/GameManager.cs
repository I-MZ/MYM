using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject clearpanel;
    public GameObject menupanel;
    public GameObject resetButton;
    public GameObject menuButton;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerController.gameState == "clear")
        {
            clearpanel.SetActive(true);
            Button rbt = resetButton.GetComponent<Button>();
            rbt.interactable = false;
            Button mbt = menuButton.GetComponent<Button>();
            mbt.interactable = false;
        }

       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        menupanel.SetActive(true);
        Button rbt = resetButton.GetComponent<Button>();
        rbt.interactable = false;
        Button mbt = menuButton.GetComponent<Button>();
        mbt.interactable = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        clearpanel.SetActive(false);
        menupanel.SetActive(false);
        Button rbt = resetButton.GetComponent<Button>();
        rbt.interactable = true;
        Button mbt = menuButton.GetComponent<Button>();
        mbt.interactable = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
