using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{

    public GameObject text; //テキスト用


    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);  //テキスト非表示

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController_a.gameState == "clear")
        {
            text.SetActive(true);  //テキスト表示
        }
    }


}
