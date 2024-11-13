using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FudebakoChanger : MonoBehaviour
{
    public GameObject PlayerObject;
    PlayerController_alpha Pcon;

    public GameObject Fudebako_Down;
    public GameObject Fudebako_Up;
    public GameObject Fudebako_Right;
    public GameObject Fudebako_Left;

    private int color = 0;

    // Start is called before the first frame update
    void Start()
    {
        Pcon = PlayerObject.GetComponent<PlayerController_alpha>();
    }

    // Update is called once per frame
    void Update()
    {
        color = Pcon.gravity;
    }

    private void FixedUpdate()
    {
        switch (color) 
        {
            case 0:

                Fudebako_Down.SetActive(true);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(false);

                break;
            case 1:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(true);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(false);

                break;
            case 2:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(true);
                Fudebako_Left.SetActive(false);

                break;
            case 3:

                Fudebako_Down.SetActive(false);
                Fudebako_Up.SetActive(false);
                Fudebako_Right.SetActive(false);
                Fudebako_Left.SetActive(true);

                break;
        }

    }
}
