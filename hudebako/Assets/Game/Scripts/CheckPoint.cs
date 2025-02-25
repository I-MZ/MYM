using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 中間地点の見た目のふるまいを制御するクラス
/// </summary>
public class CheckPoint : MonoBehaviour
{
    public static CheckPoint instance;

    public Sprite img;  //取得後のimage
    SpriteRenderer sr;
    Transform tf;
    public Vector2 Position;

    public AudioClip GetSE;

    private bool Get;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();    //SpriteRenderer取得
        tf = GetComponent<Transform>();         //Transfoam取得
        Position = tf.position;
        Get = false;
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {//プレイヤーが触れたら
            //SpriteRendererのimageを変更
            sr.sprite = img;

            //まだ取られていなければ
            if (!Get)
            {
                //取得音を鳴らす
                SceneChenger.instance.PlaySE(GetSE);
                //取ったことにする
                Get = true;
            }
        }
    }
}
