using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public GameObject StartImage;
    RectTransform rect;

    private bool DoCheck;

    private float Movespeed = 10.0f;
    private float Stoptime = 0.5f;

    [Header("開始時に鳴らすSE")] public AudioClip StartSE;


    // Start is called before the first frame update
    void Start()
    {
        DoCheck = false;
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //右から画面中央まで動かす
        if (rect.anchoredPosition.x > 0)
        {
            Move();
            Debug.Log("動かしたよ!");
        }

        //画面中央で少しとどめる
        if (rect.anchoredPosition.x == 0)
        {
            if (!DoCheck)
            {
                Invoke(nameof(PlaySound), Stoptime / 2);
                Invoke(nameof(Move), Stoptime);

                DoCheck = true;
            }
        }

        //画面中央から左に動かす
        if (rect.anchoredPosition.x < 0)
        {
            Move(Movespeed * 2);
        }

        //画面外に行ったら消す
        if (rect.anchoredPosition.x < -1000 || SceneChenger.doRetry)
        {
            Destroy(StartImage);
            PlayerController.gameState = "playing";
        }
    }

    //左に少し動かす関数
    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - Movespeed,
                                            rect.anchoredPosition.y);
    }

    //左に少し動かす関数(速度調整用)
    void Move(float movespeed)
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - movespeed,
                                            rect.anchoredPosition.y);
    }

    void PlaySound()
    {
        SceneChenger.instance.PlaySE(StartSE);
    }
}
