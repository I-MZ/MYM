using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{

    public GameObject cursor;
    private int cursor_num = 1;
    private RectTransform cursor_RTr;

    public GameObject select1;
    public GameObject select2;
    public GameObject select3;
    public GameObject select4;
    public GameObject select5;

    public GameObject nextbutton;
    public GameObject buckbutton;

    public bool GameEnd_Cuasor = false;

    //位置サンプル
    //   1   2  
    //   3   4
    //     5


    // Start is called before the first frame update
    void Start()
    {
        cursor_RTr = cursor.GetComponent<RectTransform>();

        if (select1 != null && select1.activeInHierarchy)
        {
            SetCursorPos(select1);

            cursor_num = 1;
        }
        else
        {
            SetCursorPos(select5);

            cursor_num = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameEnd_Cuasor && GameEnd.GameState == "endmode")
        {
            return;
        }

        switch (cursor_num)
        {
            case 1:
                //場所1にカーソルが合わさっている状態
                ButtonSelect(select1);
                break;
            case 2:
                //場所2にカーソルが合わさっている状態
                ButtonSelect(select2);
                break;
            case 3:
                //場所3にカーソルが合わさっている状態
                ButtonSelect(select3);
                break;
            case 4:
                //場所4にカーソルが合わさっている状態
                ButtonSelect(select4);
                break;
            case 5:
                //場所5にカーソルが合わさっている状態
                ButtonSelect(select5);
                break;
        }

        CursorMove();

        if (Input.GetKeyDown(KeyCode.Space)&&(!GameEnd_Cuasor && GameEnd.GameState == "endmode"))
        {//Spaceキーを押したら
            switch (cursor_num) 
            {
                case 1://場所1
                    //
                    Enter(select1);
                    break;
                case 2://場所2
                    //
                    Enter(select2);
                    break;
                case 3://場所3
                    //
                    Enter(select3);
                    break;
                case 4://場所4
                    //
                    Enter(select4);
                    break;
                case 5://場所5
                    //
                    Enter(select5);
                    break;
            }
        }

    }

    void ButtonSelect(GameObject select)
    {
        Button bt = select.GetComponent<Button>();
        bt.Select();

        if (select.GetComponent<EventTriggerTest>() != null)
        {
            EventTriggerTest evt = select.GetComponent<EventTriggerTest>();
            evt.Enter_Event();
        }
        
        
    }

    void ButtonSelectRemove(GameObject select)
    {
        if (select.GetComponent<EventTriggerTest>() != null)
        {
            EventTriggerTest evt = select.GetComponent<EventTriggerTest>();
            evt.Exit_Event();
        }
    }

    void CursorMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {//左入力
            switch (cursor_num)
            {
                case 1:

                    if (buckbutton != null && buckbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select1);

                        BuckPage();

                    }


                    break;
                case 2:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        ButtonSelectRemove(select2);

                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 3:

                    if (buckbutton != null && buckbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select3);

                        BuckPage();

                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 4:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        ButtonSelectRemove(select4);

                        SetCursorPos(select3);

                        cursor_num = 3;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        ButtonSelectRemove(select5);

                        SetCursorPos(select3);

                        cursor_num = 3;
                    }

                    break;
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {//右入力
            switch (cursor_num)
            {
                case 1:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        ButtonSelectRemove(select1);

                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 2:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select2);

                        NextPage();

                    }

                    break;
                case 3:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        ButtonSelectRemove(select3);

                        SetCursorPos(select4);

                        cursor_num = 4;
                    }

                    break;
                case 4:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select4);

                        NextPage();

                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 5:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        ButtonSelectRemove(select5);

                        SetCursorPos(select4);

                        cursor_num = 4;
                    }

                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {//上入力
            switch (cursor_num)
            {
                case 1:

                    

                    break;
                case 2:


                    break;
                case 3:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        ButtonSelectRemove(select3);

                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 4:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        ButtonSelectRemove(select4);

                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        ButtonSelectRemove(select5);

                        SetCursorPos(select3);

                        cursor_num = 3;
                    }
                    else if (select1 != null && select1.activeInHierarchy)
                    {
                        ButtonSelectRemove(select5);

                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {//下入力
            switch (cursor_num)
            {
                case 1:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        ButtonSelectRemove(select1);

                        SetCursorPos(select3);

                        cursor_num = 3;
                    }
                    else if (select5 != null && select5.activeInHierarchy)
                    {
                        ButtonSelectRemove(select1);

                        SetCursorPos(select5);

                        cursor_num = 5;
                    }

                    break;
                case 2:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        ButtonSelectRemove(select2);

                        SetCursorPos(select4);

                        cursor_num = 4;
                    }
                    else if (select5 != null && select5.activeInHierarchy)
                    {
                        ButtonSelectRemove(select2);

                        SetCursorPos(select5);

                        cursor_num = 5;
                    }

                    break;
                case 3:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        ButtonSelectRemove(select3);

                        SetCursorPos(select5);

                        cursor_num = 5;
                    }

                    break;
                case 4:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        ButtonSelectRemove(select4);

                        SetCursorPos(select5);

                        cursor_num = 5;
                    }

                    break;
                case 5:

                    

                    break;
            }
        }
    }

    void SetCursorPos(GameObject select)
    {
        RectTransform select_RTr = select.GetComponent<RectTransform>();


        if (cursor != null)
        {
            cursor_RTr.anchoredPosition = new Vector2(select_RTr.anchoredPosition.x + (select_RTr.sizeDelta.x / 2),
                                                      select_RTr.anchoredPosition.y + (select_RTr.sizeDelta.y / 20));

        }
        
    }

    void Enter(GameObject select)
    {

        Button bt = select.GetComponent<Button>();
        bt.onClick.Invoke();
              
    }

    void NextPage()
    {
        Button bt = nextbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }

    void BuckPage()
    {
        Button bt = buckbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }
}
