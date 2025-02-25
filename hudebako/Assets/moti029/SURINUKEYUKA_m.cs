using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SURINUKEYUKA2_m : MonoBehaviour
{
    public GameObject PlayerObject;
    PlayerController Pcnt;
    public PlayerController.GRAVITY CkopenGravity;
    //public int CkcloseGravity;

    private BoxCollider2D BC;

    Animator animator;
     string hiraku = "ZYOUGI_AKERU";
     string toziru = "ZYOUGI_SIMERU";

    string nowanime = "";
    string oldanime = "";

    // Start is called before the first frame update
    void Start()
    {
        Pcnt = PlayerObject.GetComponent<PlayerController>();
        BC = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CkopenGravity == Pcnt.gravity) 
        {
            Debug.Log("開く？");
            if (nowanime != hiraku)
            {
                Debug.Log("開いた");
            }

            BC.enabled = false;
            nowanime = hiraku;
        }
        else if(CkopenGravity != Pcnt.gravity)
        {
            if (nowanime != toziru)
            {
                Debug.Log("閉じた");
            }

            BC.enabled = true;
            nowanime = toziru;
        }

        if (nowanime != oldanime)
        {
            oldanime = nowanime;
            animator.Play(nowanime);
            Debug.Log("anime = " + nowanime);
        }



    }
}
