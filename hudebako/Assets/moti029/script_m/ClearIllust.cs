using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearIllust : MonoBehaviour
{
    [SerializeField] public GameObject Clear_Illust_Open; //クリア絵を開くボタンを入れる
    [SerializeField] public GameObject Clear_Illust_Close; //クリア絵を閉じるボタンを入れる
    [SerializeField] public GameObject GameClearPanel; //開くボタン・閉じるボタンをまとめたパネルを入れる

    //bool ClearEvent = false;    //ゴールした時に１度だけクリア絵を表示する
    //int StageClearCount;    //再度ステージをクリア時にクリア絵が表示されないようにする
    int IllustNum;    //クリア絵を表示させるための変数(0:全て非表示 1:表示ボタンを表示 2:クリア絵を表示 3:)

    //スタート関数
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
        IllustNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ステージ10クリア時
        //if (PlayerController.gameState == "clear" && ClearEvent == false && StageClearCount == 0)
        //{
        //    GameClearPanel.SetActive(true);
        //    Illust_Close();
        //    Debug.Log("1度だけクリア判定");
        //}

        //全ステージクリア後にクリア絵を表示する(現在は表示しない)
        if (StageClearManager.clearlevel == 0 && Panel_Manager_m.page_num == 2)
        //全ステージクリアしたあとステージ9と10が表示されている場所に
        {
            IllustNum = 1;
            Debug.Log("IllustNum = 1");
        }
        else
        {
            IllustNum = 0;
            Debug.Log("IllustNum = 0");
        }

        //if (IllustNum == 2)
        //{

        //}

        //クリア絵を表示させるための変数(0:全て非表示 1:表示ボタンを表示 2:クリア絵を表示 3:)

        switch (IllustNum)
        {
            case 0://クリア絵パネル表示・ボタン、クリア絵非表示
                GameClearPanel.SetActive(true);
                Clear_Illust_Open.SetActive(false);
                Clear_Illust_Close.SetActive(false);
                break;
            case 1://ボタン表示・クリア絵非表示
                Clear_Illust_Open.SetActive(true);
                Clear_Illust_Close.SetActive(false);
                break;
            case 2://ボタン非表示・クリア絵表示
                Clear_Illust_Open.SetActive(false);
                Clear_Illust_Close.SetActive(true);
                break;
        }

        if (IllustNum == 2)
        {
            //Escapeキーが押されるとクリア絵を非表示にする
            if (Input.GetKey(KeyCode.Escape))
            {
                //Close_Event();
                IllustNum = 1;
                Debug.Log("絵を閉じる");
            }

        }

       





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
    /// 押すとイラストを表示する
    /// </summary>
    public void Enter_Event()
    {
        IllustNum = 2;
        Debug.Log("絵を開く");
    }

    //public void Close_Event()
    //{
    //    IllustNum = 1;
    //    Debug.Log("絵を閉じる");
    //}

}
