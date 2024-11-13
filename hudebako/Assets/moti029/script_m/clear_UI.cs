using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clear_UI : MonoBehaviour
{
    public GameObject panel;
        
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (PlayerController_Demo_m.gameState == "clear")
	    {
            panel.SetActive(true);
	    }

    }

   
}
