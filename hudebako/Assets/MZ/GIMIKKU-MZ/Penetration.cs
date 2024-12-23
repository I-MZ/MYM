using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penetration : MonoBehaviour
{
    public GameObject PlayerObject;
    PlayerController Pcnt;
    public int CkopenGravity;
    public int CkcloseGravity;

    private BoxCollider2D BC;

    Animator animator;
     string open  = "Ruler_Open";
     string close = "Ruler_Close";

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
            if (nowanime != open)
            {
                Debug.Log("開いた");
            }

            BC.enabled = false;
            nowanime = open;
        }
        else if(CkcloseGravity==Pcnt.gravity||PlayerController.gameState=="respawn")
        {
            if (nowanime != close)
            {
                Debug.Log("閉じた");
            }

            BC.enabled = true;
            nowanime = close;
        }

        if (nowanime != oldanime)
        {
            oldanime = nowanime;
            animator.Play(nowanime);
            Debug.Log("anime = " + nowanime);
        }
    }

}
