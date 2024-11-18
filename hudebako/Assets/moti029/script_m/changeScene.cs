using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    [SerializeField] public GameObject title_button; //タイトルボタンを入れる
    [SerializeField] public GameObject Stage1_button; //ステージ1
    [SerializeField] public GameObject Stage2_button; //ステージ2
    [SerializeField] public GameObject Stage3_button; //ステージ3
    [SerializeField] public GameObject Stage4_button; //ステージ4

    [SerializeField] public GameObject Stage5_button; //ステージ5
    [SerializeField] public GameObject Stage6_button; //ステージ6
    [SerializeField] public GameObject Stage7_button; //ステージ7
    [SerializeField] public GameObject Stage8_button; //ステージ8

    [SerializeField] public GameObject Stage9_button; //ステージ9
    [SerializeField] public GameObject Stage10_button; //ステージ10


    public void Stage_select()//ステージ決定
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
        
        //セレクト画面からステージ6
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage6_button)
        {
            SceneManager.LoadScene("Stage6", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ7
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage7_button)
        {
            SceneManager.LoadScene("Stage7", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ8
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage8_button)
        {
            SceneManager.LoadScene("Stage8", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ9
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage9_button)
        {
            SceneManager.LoadScene("Stage9", LoadSceneMode.Single);
        }
        
        //セレクト画面からステージ10
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage10_button)
        {
            SceneManager.LoadScene("Stage10", LoadSceneMode.Single);
        }
        
        
    }

   
    

}


