using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite img;  //取得後のimage
    SpriteRenderer sr;  

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SuriteRenderer取得
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//プレイヤーが触れたら
            //SpriteRendererのimageを変更
            sr.sprite = img;
        }
    }
}
