using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    //インスタンス
    public static CursorController instance = null;

    //カーソル
    public GameObject cursor;           //カーソルのオブジェクト
    private RectTransform cursor_RecTr; //カーソルのRectTransform

    //カーソルがどこにいるか
    public int cursor_num;
    
    //カーソルがひとつ前にどこにいたか
    private int old_cursor_num;

    //ボタン(Unity上で設定)
    public GameObject[] Buttons = new GameObject[5];
    public GameObject Nextbutton;
    public GameObject Buckbutton;

    private int[] Bt_num;

    //ボタン位置イメージ
    //      0   1  
    //   B  2   3  N
    //        4


    //ゲーム終了確認メニューのパネルか
    public bool GameEnd_Cuasor = false;

    //カーソルが連続で動かないようにするための変数
    private bool horizontal_move = false;   //横
    private bool vertical_move = false;     //縦

    

    //スタート関数
    //
    // Start is called before the first frame update
    void Start()
    {
        //コンポーネント取得
        instance = GetComponent<CursorController>();
        cursor_RecTr = cursor.GetComponent<RectTransform>();

        //カーソル位置初期設定
        if (Buttons[0] != null && Buttons[0].activeInHierarchy)
        {
            SetCursorPos(Buttons[0]);
            cursor_num = 0;
        }
        else//select1が非アクティブならselect5を初期位置にする
        {
            SetCursorPos(Buttons[4]);
            cursor_num = 4;
        }
        old_cursor_num = cursor_num;
    }

    // Update is called once per frame
    void Update()
    {
        //入力確認用ログ
        Debug.Log("horizontal = " + Input.GetAxisRaw("Horizontal") + " : horizontal_move = " + horizontal_move);
        Debug.Log("vertical = " + Input.GetAxisRaw("Vertical") + " : vertical_move = " + vertical_move);

        //
        CheckInput();

        //
        if (!GameEnd_Cuasor && GameEnd.GameState == "endmode")
        {
            return;
        }

        Debug.Log(Buttons[0]);

        //Escキーが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //カーソル位置を初期化
            if (Buttons[0] != null && Buttons[0].activeInHierarchy)
            {
                SetCursorPos(Buttons[0]);

                cursor_num = 0;
            }
            else
            {
                SetCursorPos(Buttons[4]);

                cursor_num = 4;
            }
        }

        //カーソルが合っているボタンを選択状態にする
        for(int i = 0; i < 5; i++)
        {
            if (cursor_num == i)
            {
                ButtonSelect(Buttons[i]);
            }
        }

        CursorControll();

        if (Input.GetKeyDown(KeyCode.Space)&&(!GameEnd_Cuasor && GameEnd.GameState == "endmode"))
        {//Spaceキーが押されたら
            for (int i = 0; i < 5; i++)
            {
                if (cursor_num == i)
                {
                    Enter(Buttons[i]);
                }
            }
        }

        

    }

    void CheckInput()
    {
        //横方向
        if (Input.GetAxisRaw("Horizontal") == 0)
        {//入力なしならカーソルを動かせるようにする
            horizontal_move = true;
        }

        //縦方向
        if (Input.GetAxisRaw("Vertical") == 0)
        {//入力なしならカーソルを動かせるようにする
            vertical_move = true;
        }
    }   


    void CursorControll()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && horizontal_move)
        {//左入力
            switch (cursor_num)
            {
                case 0:

                    if (Buckbutton != null && Buckbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(Buttons[0]);

                        BuckPage();

                        old_cursor_num = 0;
                    }


                    break;
                case 1:

                    if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[1], Buttons[0], 1, 0);
                    }

                    break;
                case 2:

                    if (Buckbutton != null && Buckbutton.activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[0], 2, 0);

                        BuckPage();

                    }

                    break;
                case 3:

                    if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[2], 3, 2);
                    }

                    break;
                case 4:

                    if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[4], Buttons[2], 4, 2);
                    }

                    break;
            }

            horizontal_move = false;
        }
        if (Input.GetAxisRaw("Horizontal") > 0 && horizontal_move)
        {//右入力
            switch (cursor_num)
            {
                case 0:

                    if (Buttons[1] != null && Buttons[1].activeInHierarchy)
                    {
                        CursorMove(Buttons[0], Buttons[1], 0, 1);
                    }

                    break;
                case 1:

                    if (Nextbutton != null && Nextbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(Buttons[1]);

                        NextPage();

                        old_cursor_num = 1;
                    }

                    break;
                case 2:

                    if (Buttons[3] != null && Buttons[3].activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[3], 2, 3);
                    }

                    break;
                case 3:

                    if (Nextbutton != null && Nextbutton.activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[1], 3, 1);

                        NextPage();
                    }

                    break;
                case 4:

                    if (Buttons[3] != null && Buttons[3].activeInHierarchy)
                    {
                        CursorMove(Buttons[4], Buttons[3], 4, 3);
                    }

                    break;
            }

            horizontal_move = false;
        }
        if (Input.GetAxisRaw("Vertical") > 0 && vertical_move)
        {//上入力
            switch (cursor_num)
            {
                case 0:

                    

                    break;
                case 1:


                    break;
                case 2:

                    if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[0], 2, 1);
                    }

                    break;
                case 3:

                    if (Buttons[1] != null && Buttons[1].activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[1], 3, 1);
                    }
                    else if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[0], 3, 0);
                    }

                    break;
                case 4:

                    if (Buttons[2] != null && Buttons[2].activeInHierarchy && old_cursor_num == 2)
                    {
                        CursorMove(Buttons[4], Buttons[2], 4, 2);
                    }
                    else if (Buttons[3] != null && Buttons[3].activeInHierarchy && old_cursor_num == 3)
                    {
                        CursorMove(Buttons[4], Buttons[3], 4, 3);
                    }
                    else if (Buttons[0] != null && Buttons[0].activeInHierarchy && old_cursor_num == 0)
                    {
                        CursorMove(Buttons[4], Buttons[0], 4, 0);
                    }
                    else if (Buttons[1] != null && Buttons[1].activeInHierarchy && old_cursor_num == 1)
                    {
                        CursorMove(Buttons[4], Buttons[1], 4, 1);
                    }
                    else if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[4], Buttons[2], 4, 2);
                    }
                    else if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[4], Buttons[0], 4, 0);
                    }

                    break;
            }

            vertical_move = false;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && vertical_move)
        {//下入力
            switch (cursor_num)
            {
                case 0:

                    if (Buttons[2] != null && Buttons[2].activeInHierarchy && old_cursor_num == 2)
                    {
                        CursorMove(Buttons[0], Buttons[2], 0, 2);
                    }
                    else if (Buttons[3] != null && Buttons[3].activeInHierarchy && old_cursor_num == 3)
                    {
                        CursorMove(Buttons[0], Buttons[3], 0, 3);
                    }
                    else if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[0], Buttons[2], 0, 2);
                    }
                    else if (Buttons[4] != null && Buttons[4].activeInHierarchy)
                    {
                        CursorMove(Buttons[0], Buttons[4], 0, 4);
                    }

                    break;
                case 1:

                    if (Buttons[3] != null && Buttons[3].activeInHierarchy)
                    {
                        CursorMove(Buttons[1], Buttons[3], 1, 3);
                    }
                    else if (Buttons[4] != null && Buttons[4].activeInHierarchy)
                    {
                        CursorMove(Buttons[1], Buttons[4], 1, 4);
                    }

                    break;
                case 2:

                    if (Buttons[4] != null && Buttons[4].activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[4], 2, 4);
                    }

                    break;
                case 3:

                    if (Buttons[4] != null && Buttons[4].activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[4], 3, 4);
                    }

                    break;
                case 4:

                    

                    break;
            }

            vertical_move = false;
        }
    }


    //カーソルがボタンを選んでいるときの処理
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

    //カーソルがボタンから出たときの処理
    void ButtonSelectRemove(GameObject select)
    {
        if (select.GetComponent<EventTriggerTest>() != null)
        {
            EventTriggerTest evt = select.GetComponent<EventTriggerTest>();
            evt.Exit_Event();
        }
    }

    //カーソルを選ばれているボタンの横に移動させる
    public void SetCursorPos(GameObject select)
    {
        RectTransform select_RecTr = select.GetComponent<RectTransform>();

        if (cursor != null)
        {
            cursor_RecTr.anchoredPosition = new Vector2(select_RecTr.anchoredPosition.x + (select_RecTr.sizeDelta.x / 2),
                                                        select_RecTr.anchoredPosition.y + (select_RecTr.sizeDelta.y / 20));

        }
        
    }

    //カーソル移動処理
    void CursorMove(GameObject old_select, GameObject select, int now_num, int new_num)
    {
        ButtonSelectRemove(old_select);

        SetCursorPos(select);

        cursor_num = new_num;
        old_cursor_num = now_num;
    }

    void Enter(GameObject select)
    {

        Button bt = select.GetComponent<Button>();
        bt.onClick.Invoke();
              
    }

    void NextPage()
    {
        Button bt = Nextbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }

    void BuckPage()
    {
        Button bt = Buckbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }
}
