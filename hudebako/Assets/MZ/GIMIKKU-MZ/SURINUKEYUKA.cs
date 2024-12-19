using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SURINUKEYUKA : MonoBehaviour
{
    public GameObject PlayerObject;
    PlayerController Pcnt;
    public int CkopenGravity;
    public int CkcloseGravity;

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
            Debug.Log("äJÇ≠ÅH");
            if (nowanime != hiraku)
            {
                Debug.Log("äJÇ¢ÇΩ");
            }

            BC.enabled = false;
            nowanime = hiraku;
        }
        else if(CkcloseGravity==Pcnt.gravity||PlayerController.gameState=="respawn")
        {
            if (nowanime != toziru)
            {
                Debug.Log("ï¬Ç∂ÇΩ");
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
