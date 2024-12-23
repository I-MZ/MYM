using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityChecker : MonoBehaviour
{
    Image Img;

    public Sprite ArrowDown;    //下矢印
    public Sprite ArrowUp;      //上矢印
    public Sprite ArrowRight;   //右矢印
    public Sprite ArrowLeft;    //左矢印

    // Start is called before the first frame update
    void Start()
    {
        Img = GetComponent<Image>();    //Imageコンポーネントを取得

    }

    // Update is called once per frame
    void Update()
    {
        //PleyerControllerがnullじゃないか確認
        if (PlayerController.instance != null)
        {
            switch (PlayerController.instance.gravity) 
            {//PlayerControllerのgravity(重力の向き)をチェック

                case 0://下のとき
                    Img.sprite = ArrowDown; //下矢印に
                    break;
                case 1://上のとき
                    Img.sprite = ArrowUp;   //上矢印に
                    break;
                case 2://右のとき
                    Img.sprite = ArrowRight;//右矢印に
                    break;
                case 3://左のとき
                    Img.sprite = ArrowLeft; //左矢印に
                    break;
            }

            //PlayerControllerのforcepower(重力の強さ)をチェック
            if (PlayerController.instance.forcepower)
            {//true(強い状態)
                //色を暗くする
                Img.color = new Color(0.7f, 0.7f, 0.7f);
            }
            else
            {//false(弱い状態)
                //色を戻す
                Img.color = new Color(1, 1, 1);
            }
        }
    }
}
