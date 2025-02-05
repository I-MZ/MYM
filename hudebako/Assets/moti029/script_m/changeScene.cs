using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changeScene : MonoBehaviour
{
    private void ButtonStateColorChange(Button button, Color32 color, int changeState)
    {
        ColorBlock colorblock = button.colors;
        switch (changeState)
        {
            case 0://normalColor
                colorblock.normalColor = color;
                break;
            case 1://highlightedColor
                colorblock.highlightedColor = color;
                break;
            case 2://pressedColor
                colorblock.pressedColor = color;
                break;
            case 3://selectedColor
                colorblock.selectedColor = color;
                break;
            case 4://disabledColor
                colorblock.disabledColor = color;
                break;
        }
        button.colors = colorblock;
    }

    [SerializeField] public Button select_button; //ボタンを入れる
    int stage_num = 0;

    private void Start()
    {
       
    }

    public void Stage_select()//ステージ決定
    {
        if (select_button)
        {
            if (select_button.name == "Stage1_button")
                stage_num = 0;
            if (select_button.name == "Stage2_button")
                stage_num = 1;
            if (select_button.name == "Stage3_button")
                stage_num = 2;
            if (select_button.name == "Stage4_button")
                stage_num = 3;
            if (select_button.name == "Stage5_button")
                stage_num = 4;
            if (select_button.name == "Stage6_button")
                stage_num = 5;
            if (select_button.name == "Stage7_button")
                stage_num = 6;
            if (select_button.name == "Stage8_button")
                stage_num = 7;
            if (select_button.name == "Stage9_button")
                stage_num = 8;
            if (select_button.name == "Stage10_button")
                stage_num = 9;
            if (select_button.name == "Stage_select_button")
                stage_num = 10;
        }

        switch (stage_num)
        {
            case 0:
                //ゲームを最初から初めても
                if (StageClearManager.clearlevel >= 0)
                {
                    //ステージ1にはいれる
                    SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
                }
                break;
            case 1:
                if (StageClearManager.clearlevel >= 1)
                {
                    SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
                }
                    
                break;
            case 2:
                if (StageClearManager.clearlevel >= 2)
                {
                    SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
                }
                
                break;
            case 3:
                if (StageClearManager.clearlevel >= 3)
                {
                    SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
                }
                
                break; 
            case 4:
                if (StageClearManager.clearlevel >= 4)
                {
                    SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
                }
                
                break;
            case 5:
                if (StageClearManager.clearlevel >= 5)
                {
                    SceneManager.LoadScene("Stage6", LoadSceneMode.Single);
                }
                
                break;
            case 6:
                if (StageClearManager.clearlevel >= 6)
                {
                    SceneManager.LoadScene("Stage7", LoadSceneMode.Single);
                }
                
                break;
            case 7:
                if (StageClearManager.clearlevel >= 7)
                {
                    SceneManager.LoadScene("Stage8", LoadSceneMode.Single);
                }
                
                break; 
            case 8:
                if (StageClearManager.clearlevel >= 8)
                {
                    SceneManager.LoadScene("Stage9", LoadSceneMode.Single);
                }
                
                break;
            case 9:
                if (StageClearManager.clearlevel >= 9)
                {
                    SceneManager.LoadScene("Stage10", LoadSceneMode.Single);
                }
                
                break;
            case 10://ステージセレクト画面
                SceneManager.LoadScene("StageSelect", LoadSceneMode.Single);
                break;

        }

        
       
    }

  
}


