using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンを押すとゲームクリアシーンに飛ばすように変更予定

//流れ
/*
ステージ10の旗に触れてステージクリアの文字が流れた後に
フェードアウトしてからゲームクリアシーンに飛ばす
ステージセレクトシーンに戻ってきたらステージ9の下にクリア絵表示ボタンを表示
そのボタンを押すと再度ゲームクリアシーンに飛ぶ(Escキーでステージセレクトシーンに移動)
再度ゲームクリアシーンに飛んだ場合はクリア絵のみ表示するようにする
初回クリア時はクリア絵表示のほかに演出を追加する？
 */
public class ClearIllust : MonoBehaviour
{
    [SerializeField] public GameObject Clear_Illust_Open; //クリア絵を開くボタンを入れる
    [SerializeField] public GameObject Clear_Illust_Close; //クリア絵を閉じるボタンを入れる
    [SerializeField] public GameObject GameClearPanel; //開くボタン・閉じるボタンをまとめたパネルを入れる

    [Header("決定時に鳴らすSE")] public AudioClip enter;
    [Header("キャンセル時に鳴らすSE")] public AudioClip cancel;

    bool IllustPanelOpen = false;    //クリアパネルを表示しているか(true:表示 false:非表示)
    bool IllustOpen = false;    //クリア絵を表示しているか(true:表示 false:非表示)


    //スタート関数
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
        IllustPanelOpen = false;
        IllustOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //全ステージクリア後にクリア絵を見るためのシーンに移動するためのボタンを表示
        //(現在はステージ1をクリアしていない場合のみ表示)
        if (StageClearManager.clearlevel == 0 && Panel_Manager_m.page_num == 2)
        //全ステージクリアしたあとステージ9の下にボタンを表示
        {
            IllustPanelOpen = true;
            Debug.Log("クリア絵パネル表示");
        }
        else
        {
            IllustPanelOpen = false;
            Debug.Log("クリア絵パネル非表示");
        }


        //クリア絵を表示させるための変数(0:全て非表示 1:表示ボタンを表示 2:クリア絵を表示 3:)

        //switch (IllustNum)
        //{
        //    case 0://クリア絵パネル表示・ボタン、クリア絵非表示
        //        GameClearPanel.SetActive(true);
        //        Clear_Illust_Open.SetActive(false);
        //        Clear_Illust_Close.SetActive(false);
        //        break;
        //    case 1://ボタン表示・クリア絵非表示
        //        Clear_Illust_Open.SetActive(true);
        //        Clear_Illust_Close.SetActive(false);
        //        break;
        //    case 2://ボタン非表示・クリア絵表示
        //        Clear_Illust_Open.SetActive(false);
        //        Clear_Illust_Close.SetActive(true);
        //        break;
        //}
        if (IllustPanelOpen)//IllustPanelOpenがtrueなら
        {
            //クリア絵パネル表示・ボタン、クリア絵非表示
            GameClearPanel.SetActive(true);
            Clear_Illust_Open.SetActive(true);
            Clear_Illust_Close.SetActive(false);
        }
        else
        {
            //falseなら全て非表示
            GameClearPanel.SetActive(true);
            Clear_Illust_Open.SetActive(false);
            Clear_Illust_Close.SetActive(false);
        }

        //if (IllustOpen)//IllustOpenがtrueなら
        //{
        //    Clear_Illust_Close.SetActive(true);
        //    Debug.Log("クリア絵を表示");

        //}


        //if (IllustOpen == true)
        //{
        //    //Escapeキーが押されるとステージセレクト画面に戻る
        //    if (Input.GetKey(KeyCode.Escape))
        //    {
        //        IllustOpen = false;
        //        Debug.Log("絵を閉じる");
        //    }


        //}


        //public void Illust_Open()//クリア絵を開くボタンを表示する
        //    {
        //        Clear_Illust_Open.SetActive(true);
        //        Clear_Illust_Close.SetActive(false);

        //    }
        //    public void Illust_Close()//クリア絵と閉じるボタンを表示する
        //    {
        //        Clear_Illust_Close.SetActive(true);
        //        Clear_Illust_Open.SetActive(false);
        //        Debug.Log("クリア絵を表示");

        //        //Escapeキーが押されるとクリア絵を非表示にする
        //        if (Input.GetKey(KeyCode.Escape))
        //        {
        //            Illust_Open();

        //            //ClearEvent = true;
        //            //StageClearCount++;
        //        }
        //    }

    }
    /// <summary>
    /// 押すとクリアシーンに移動
    /// </summary>
    public void Enter_Event()
    {
        //IllustOpen = true;
        Debug.Log("クリアシーンへ移動");
    }

    //public void Close_Event()
    //{
    //    IllustNum = 1;
    //    Debug.Log("絵を閉じる");
    //}
    public void PlaySE()
    {
        if (IllustOpen)
        {
            SceneChenger.instance.PlaySE(enter);
            Debug.Log("enterSEを鳴らす");
        }
        else
        {
            SceneChenger.instance.PlaySE(cancel);
            Debug.Log("canselSEを鳴らす");
        }
    }
}

