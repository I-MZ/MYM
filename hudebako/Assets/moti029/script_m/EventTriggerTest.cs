using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
    [SerializeField] public GameObject SelectObject;        //ステージボタンが選択されると
    [SerializeField] public GameObject SelectObject_arrow;  //黄色の矢印がステージボタンの上に表示
    public int num;                                         //どのステージを選択しているか(1:左上2:右上3:左下4:右上)

    private void Start()
    {
        SelectObject_arrow.SetActive(false);
    }

    public void Enter_Event()
    {

        //
        if (SelectObject)
        {
            if (SelectObject.name == "Stage1_button" ||
                SelectObject.name == "Stage5_button" ||
                SelectObject.name == "Stage9_button")
            {
                Debug.Log("num1");
                num = 1;//矢印は左上に表示される
            }
            else if (SelectObject.name == "Stage2_button" ||
                     SelectObject.name == "Stage6_button" ||
                     SelectObject.name == "Stage10_button")
            {
                Debug.Log("num2");
                num = 2;//矢印は右上に表示される
            }
            else if (SelectObject.name == "Stage3_button" ||
                     SelectObject.name == "Stage7_button" ||
                     SelectObject.name == "Clear")
            {
                Debug.Log("num3");
                num = 3;//矢印は左下に表示される
            }
            else if (SelectObject.name == "Stage4_button" ||
                     SelectObject.name == "Stage8_button" )
                     
            {
                Debug.Log("num4");
                num = 4;//矢印は右下に表示される
            }
            else
            {
                SelectObject_arrow.SetActive(false);
                num = 0;
            }



            //矢印を表示する条件
            if (num == 1 && SelectObject_arrow.name == "select_arrowUL")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("左上表示");
            }
            if (num == 2 && SelectObject_arrow.name == "select_arrowUR")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("右上表示");
            }
            if (num == 3 && SelectObject_arrow.name == "select_arrowDL")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("左下表示");
            }
            if (num == 4 && SelectObject_arrow.name == "select_arrowDR")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("右下表示");
            }

            //Debug.Log("イベント発生！");
        }
    }

    public void Exit_Event()
    //矢印を非表示にする
    {
        SelectObject_arrow.SetActive(false);//矢印を非表示にする

        Debug.Log("イベント非表示！");
    }
}