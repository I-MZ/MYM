using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMove : MonoBehaviour
{

    public GameObject ClearImage;
    RectTransform rect;

    private float Movespeed = 10.0f;
    private float Stoptime = 0.5f;

    public static bool Movefinish = false;
    private bool DoCheck;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        DoCheck = false;
        Movefinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState != "clear")
        {
            return;
        }

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
                Invoke(nameof(Move), Stoptime);
                DoCheck = true;
            }
        }

        //画面中央から左に動かす
        if (rect.anchoredPosition.x < 0)
        {
            Move();
        }

        //画面外に行ったら消す
        if (rect.anchoredPosition.x < -700 || SceneChenger.doRetry)
        {
            Movefinish = true;
            Destroy(ClearImage);
        }
    }

    //左に少し動かす関数
    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - Movespeed,
                                            rect.anchoredPosition.y);
    }
}
