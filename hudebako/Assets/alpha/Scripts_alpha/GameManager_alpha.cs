using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_alpha : MonoBehaviour
{
    public GameObject panel;
    public GameObject resetButton;


    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController_alpha.gameState == "clear")
        {
            panel.SetActive(true);
            Button bt = resetButton.GetComponent<Button>();
            bt.interactable = false;
        }
    }
}