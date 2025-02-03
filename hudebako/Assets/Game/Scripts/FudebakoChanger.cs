using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FudebakoChanger : MonoBehaviour
{

    public GameObject Fudebako_Down;
    public GameObject Fudebako_Up;
    public GameObject Fudebako_Right;
    public GameObject Fudebako_Left;

    public GameObject ChengeColor;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        switch (PlayerController.instance.gravity) 
        {
            case PlayerController.GRAVITY.DOWN:

                Fudebako_Down.SetActive(true);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(false);

                break;
            case PlayerController.GRAVITY.UP:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(true);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(false);

                break;
            case PlayerController.GRAVITY.RIGHT:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(true);
                Fudebako_Left.SetActive(false);

                break;
            case PlayerController.GRAVITY.LEFT:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(true);

                break;
        }

        if(ChengeColor!=null)
        {
            if (PlayerController.instance.forcepower)
            {
                ChengeColor.SetActive(true);
            }
            else
            {
                ChengeColor.SetActive(false);
            }
        }
        

    }
}
