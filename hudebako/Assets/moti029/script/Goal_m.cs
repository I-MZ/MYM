using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Goal : MonoBehaviour
{

    public GameObject text; //�e�L�X�g�p


    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);  //�e�L�X�g��\��

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController_a.gameState == "clear")
        {
            text.SetActive(true);  //�e�L�X�g�\��
        }
    }


}
