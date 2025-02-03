using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中間地点の見た目のふるまいを制御するクラス
/// </summary>
public class CheckPoint : MonoBehaviour
{
    public Sprite img;  //取得後のimage
    SpriteRenderer sr;

    public AudioClip GetSE;

    private bool Get;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SpriteRenderer取得
        Get = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//プレイヤーが触れたら
            //SpriteRendererのimageを変更
            sr.sprite = img;
            if (!Get)
            {
                SceneChenger.instance.PlaySE(GetSE);
                Get = true;
            }
        }
    }
}
