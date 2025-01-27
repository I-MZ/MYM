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

    //スタート関数
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
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
        if (StageClearManager.clearlevel == 12 && Panel_Manager_m.page_num == 2)
            //全ステージクリアしたあとステージ9と10が表示されている場所に
        {
            //GameClearPanel.SetActive(true);//クリア絵に関するパネルを表示
            Illust_Open();//クリア絵を表示するボタンを表示
        }
        else
        {
            Clear_Illust_Open.SetActive(false);//クリア絵を表示するボタンを非表示
        }
    }

    
  


    public void Illust_Open()//クリア絵を開くボタンを表示する
    {
        Clear_Illust_Open.SetActive(true);
        Clear_Illust_Close.SetActive(false);

    }
    public void Illust_Close()//クリア絵と閉じるボタンを表示する
    {
        Clear_Illust_Close.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Debug.Log("クリア絵を表示");

        //Escapeキーが押されるとクリア絵を非表示にする
        if (Input.GetKey(KeyCode.Escape))
        {
            Illust_Open();

            //ClearEvent = true;
            //StageClearCount++;
        }
    }

}
