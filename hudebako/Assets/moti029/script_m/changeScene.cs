using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    [SerializeField] public GameObject title_button; //タイトルボタンを入れる
    [SerializeField] public GameObject Stage1_button; //ステージ1ボタンを入れる
    [SerializeField] public GameObject Stage2_button; //ステージ2ボタンを入れる
    [SerializeField] public GameObject Stage3_button; //ステージ3ボタンを入れる
    [SerializeField] public GameObject Stage4_button; //ステージ4ボタンを入れる

    [SerializeField] public GameObject Stage5_button; //ステージ5ボタンを入れる


    [SerializeField] public GameObject Select_R; //右矢印ボタンを入れる
    [SerializeField] public GameObject Select_L; //左矢印ボタンを入れる



    public void change_button()
    {
       //タイトル画面からセレクト画面へ
        if (title_button)
        {
            SceneManager.LoadScene("Stage_Select_Scene_m", LoadSceneMode.Single);
        } 
        
        //セレクト画面からステージ1
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage1_button)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ2
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage2_button)
        {
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ3
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage3_button)
        {
            SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ4
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage4_button)
        {
            SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ5
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage5_button)
        {
            SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
        }
        
        
    }

    public void select_LR()//クリックしたボタンの情報を入れる
    {
        if ()
        {
            Stage1_button = stage5_button;
            Select_R.SetActive(false);
        }
        
    }
}


