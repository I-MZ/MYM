using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//定規
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

    //スタート関数
    //説明
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        Pcnt     = PlayerObject.GetComponent<PlayerController>();
        BC       = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //定規の開閉
        if (CkopenGravity == Pcnt.gravity) 
        {
            Debug.Log("開く？");
            
            //開ける
            if (nowanime != open)
            {
                Debug.Log("開いた");
            }

            BC.enabled = false;//当たり判定を無効化する
            nowanime   = open; //開けるアニメーションに変更
        }
        else if(CkcloseGravity==Pcnt.gravity||PlayerController.gameState=="respawn")
        {

            if (nowanime != close)//閉める
            {
                Debug.Log("閉じた");
            }

            BC.enabled = true; //当たり判定を有効化する
            nowanime   = close;//閉めるアニメーションに変更
        }

        //アニメーションの変更の処理
        if (nowanime != oldanime)   //アニメーションが同じか確認する
        {
            oldanime = nowanime;    //oldanimeに新しいアニメーションを設定する
            animator.Play(nowanime);//nowanimeに入っているアニメーションを流す
            Debug.Log("anime = " + nowanime);
        }
    }

}
