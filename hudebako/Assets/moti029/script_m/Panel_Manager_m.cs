using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Panel_Manager_m : MonoBehaviour
{
    GameObject[] Panels = { };




    [SerializeField] public GameObject Panel0; //1-4ステージパネル
    [SerializeField] public GameObject Panel1; //5-8ステージパネル
    [SerializeField] public GameObject Panel2; //9-10ステージパネル

    [SerializeField] public GameObject Select_R; //右矢印ボタンを入れる
    [SerializeField] public GameObject Select_L; //左矢印ボタンを入れる

    public static int page_num;

    [Header("ページを切り替える時のSE")] public AudioClip Paging;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        page_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (page_num == 0)//ステージ1-4
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Select_L.SetActive(false);
            Select_R.SetActive(true);
        }

        if (page_num == 1)//ステージ5-8
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Select_L.SetActive(true);
            Select_R.SetActive(true);
        }

        if (page_num == 2)//ステージ9-10
        {
            Panel0.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Select_L.SetActive(true);
            Select_R.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
    }

    //ページ切り替え関数(右)
    //ステージセレクト画面でステージ9,10が表示されている時
    //パネルを表示している時ページ番号を1減らす
    public void num_plus_R()
    {
        if (page_num < 2)//右
        {
            SceneChenger.instance.PlaySE(Paging);
            page_num++;
        }
       
       
    }

    //ページ切り替え関数(左)
    //ステージセレクト画面でステージ1,2,3,4が表示されている時
    //パネルを表示している時ページ番号を1減らす
    public void num_plus_L()
    {
        
        if (page_num > 0)//左
        {
            SceneChenger.instance.PlaySE(Paging);
            page_num--;
        }

       
        
    }

   

    //public void panel_num()//ステージ1～10のtrue.false切り替え
    //{
    //    if (stage_num == 0)//ステージ1-4
    //    {
    //        Panel0.SetActive(true);
    //        Panel1.SetActive(false);
    //        Panel2.SetActive(false);
    //        Select_L.SetActive(false);
    //        Select_R.SetActive(true);
    //    }

    //    if (stage_num == 1)//ステージ5-8
    //    {
    //        Panel0.SetActive(false);
    //        Panel1.SetActive(true);
    //        Panel2.SetActive(false);
    //        Select_L.SetActive(true);
    //        Select_R.SetActive(true);
    //    }

    //    if (stage_num == 2)//ステージ9-10
    //    {
    //        Panel0.SetActive(false);
    //        Panel1.SetActive(false);
    //        Panel2.SetActive(true);
    //        Select_L.SetActive(true);
    //        Select_R.SetActive(false);
    //    }
    //}


}
