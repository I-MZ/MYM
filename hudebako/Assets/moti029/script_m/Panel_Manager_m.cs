using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Panel_Manager_m : MonoBehaviour
{
    [SerializeField] public GameObject Panel0; //1-4ステージパネル
    [SerializeField] public GameObject Panel1; //5-8ステージパネル
    [SerializeField] public GameObject Panel2; //9-10ステージパネル

    [SerializeField] public GameObject Select_R; //右矢印ボタンを入れる
    [SerializeField] public GameObject Select_L; //左矢印ボタンを入れる

    int stage_num;

    [Header("ページを切り替える時のSE")] public AudioClip Paging;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        stage_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage_num == 0)//ステージ1-4
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Select_L.SetActive(false);
            Select_R.SetActive(true);
        }

        if (stage_num == 1)//ステージ5-8
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Select_L.SetActive(true);
            Select_R.SetActive(true);
        }

        if (stage_num == 2)//ステージ9-10
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

    public void num_plus_R()
    {
        if (stage_num < 2)//右
        {
            SceneChenger.instance.PlaySE(Paging);
            stage_num++;
        }
       
       
    }
    
    public void num_plus_L()
    {
        
        if (stage_num > 0)//左
        {
            SceneChenger.instance.PlaySE(Paging);
            stage_num--;
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
