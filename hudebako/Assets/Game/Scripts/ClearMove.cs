using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMove : MonoBehaviour
{

    public GameObject ClearImage;
    RectTransform rect;

    private float Movespeed = 10.0f;
    private float Stoptime = 0.5f;

    private float Destroy_border = -700.0f;

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

        //右から画面中央まで動かし続ける
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

        //画面中央から左に動かし続ける
        if (rect.anchoredPosition.x < 0)
        {
            Move();
        }

        //画面外に行ったら消す
        if (rect.anchoredPosition.x < Destroy_border || SceneChenger.doRetry)
        {
            Movefinish = true;
            Destroy(ClearImage);
        }
    }

    /// <summary>
    /// 位置を少し左にずらす
    /// </summary>
    void Move()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x - Movespeed,
                                            rect.anchoredPosition.y);
    }
}
