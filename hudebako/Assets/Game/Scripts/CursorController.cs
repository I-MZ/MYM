using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CursorController : MonoBehaviour
{
    public static CursorController instance = null;

    public GameObject cursor;
    public int cursor_num = 1;
    private int old_cursor_num;
    private RectTransform cursor_RecTr;

    public GameObject select1;
    public GameObject select2;
    public GameObject select3;
    public GameObject select4;
    public GameObject select5;

    public GameObject nextbutton;
    public GameObject buckbutton;

    public bool GameEnd_Cuasor = false;

    //���͊֌W
    private int horizontal = 0;
    private int vertical = 0;
    private bool horizontal_move = false;
    private bool vertical_move = false;

    //�ʒu�T���v��
    //   1   2  
    //   3   4
    //     5


    // Start is called before the first frame update
    void Start()
    {
        instance = GetComponent<CursorController>();

        cursor_RecTr = cursor.GetComponent<RectTransform>();

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
        old_cursor_num = cursor_num;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("horizontal = " + horizontal + " : horizontal_move = " + horizontal_move);
        Debug.Log("vertical = " + vertical + " : vertical_move = " + vertical_move);

        CheckInput();

        if (!GameEnd_Cuasor && GameEnd.GameState == "endmode")
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
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

        switch (cursor_num)
        {
            case 1:
                //�ꏊ1�ɃJ�[�\�������킳���Ă�����
                ButtonSelect(select1);
                break;
            case 2:
                //�ꏊ2�ɃJ�[�\�������킳���Ă�����
                ButtonSelect(select2);
                break;
            case 3:
                //�ꏊ3�ɃJ�[�\�������킳���Ă�����
                ButtonSelect(select3);
                break;
            case 4:
                //�ꏊ4�ɃJ�[�\�������킳���Ă�����
                ButtonSelect(select4);
                break;
            case 5:
                //�ꏊ5�ɃJ�[�\�������킳���Ă�����
                ButtonSelect(select5);
                break;
        }

        CursorControll();

        if (Input.GetKeyDown(KeyCode.Space)&&(!GameEnd_Cuasor && GameEnd.GameState == "endmode"))
        {//Space�L�[����������
            switch (cursor_num) 
            {
                case 1://�ꏊ1
                    //
                    Enter(select1);
                    break;
                case 2://�ꏊ2
                    //
                    Enter(select2);
                    break;
                case 3://�ꏊ3
                    //
                    Enter(select3);
                    break;
                case 4://�ꏊ4
                    //
                    Enter(select4);
                    break;
                case 5://�ꏊ5
                    //
                    Enter(select5);
                    break;
            }
        }

        

    }

    void CheckInput()
    {
        //������
        if (Input.GetAxisRaw("Horizontal") < 0)
        {//������
            horizontal = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {//�E����
            horizontal = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {//���͂Ȃ�
            horizontal = 0;

            horizontal_move = true;
        }

        //�c����
        if (Input.GetAxisRaw("Vertical") < 0)
        {//������
            vertical = -1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {//�����
            vertical = 1;
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {//���͂Ȃ�
            vertical = 0;

            vertical_move = true;
        }
    }   

    void CursorControll()
    {
        if (horizontal < 0 && horizontal_move)
        {//������
            switch (cursor_num)
            {
                case 1:

                    if (buckbutton != null && buckbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select1);

                        BuckPage();

                        old_cursor_num = 1;
                    }


                    break;
                case 2:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        CursorMove(select2, select1);

                        cursor_num = 1;

                        old_cursor_num = 2;
                    }

                    break;
                case 3:

                    if (buckbutton != null && buckbutton.activeInHierarchy)
                    {
                        CursorMove(select3, select1);

                        BuckPage();

                        cursor_num = 1;

                        old_cursor_num = 3;
                    }

                    break;
                case 4:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        CursorMove(select4, select3);

                        cursor_num = 3;

                        old_cursor_num = 4;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        CursorMove(select5, select3);

                        cursor_num = 3;

                        old_cursor_num = 5;
                    }

                    break;
            }

            horizontal_move = false;
        }
        if (horizontal > 0 && horizontal_move)
        {//�E����
            switch (cursor_num)
            {
                case 1:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        CursorMove(select1, select2);

                        cursor_num = 2;

                        old_cursor_num = 1;
                    }

                    break;
                case 2:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(select2);

                        NextPage();

                        old_cursor_num = 2;
                    }

                    break;
                case 3:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        CursorMove(select3, select4);

                        cursor_num = 4;

                        old_cursor_num = 3;
                    }

                    break;
                case 4:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        CursorMove(select4, select2);

                        NextPage();

                        cursor_num = 2;

                        old_cursor_num = 4;
                    }

                    break;
                case 5:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        CursorMove(select5, select4);

                        cursor_num = 4;

                        old_cursor_num = 5;
                    }

                    break;
            }

            horizontal_move = false;
        }
        if (vertical > 0 && vertical_move)
        {//�����
            switch (cursor_num)
            {
                case 1:

                    

                    break;
                case 2:


                    break;
                case 3:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        CursorMove(select3, select1);

                        cursor_num = 1;

                        old_cursor_num = 3;
                    }

                    break;
                case 4:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        CursorMove(select4, select2);

                        cursor_num = 2;

                        old_cursor_num = 4;
                    }
                    else if (select1 != null && select1.activeInHierarchy)
                    {
                        CursorMove(select3, select1);

                        cursor_num = 1;

                        old_cursor_num = 4;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy && old_cursor_num == 3)
                    {
                        CursorMove(select5, select3);

                        cursor_num = 3;

                        old_cursor_num = 5;
                    }
                    else if (select1 != null && select1.activeInHierarchy && old_cursor_num == 4)
                    {
                        CursorMove(select5, select4);

                        cursor_num = 4;

                        old_cursor_num = 5;
                    }
                    else if (select3 != null && select3.activeInHierarchy && old_cursor_num == 1)
                    {
                        CursorMove(select5, select1);

                        cursor_num = 1;

                        old_cursor_num = 5;
                    }
                    else if (select1 != null && select1.activeInHierarchy && old_cursor_num == 2)
                    {
                        CursorMove(select5, select2);

                        cursor_num = 2;

                        old_cursor_num = 5;
                    }
                    else if (select3 != null && select3.activeInHierarchy)
                    {
                        CursorMove(select5, select3);

                        cursor_num = 3;

                        old_cursor_num = 5;
                    }
                    else if (select1 != null && select1.activeInHierarchy)
                    {
                        CursorMove(select5, select1);

                        cursor_num = 1;

                        old_cursor_num = 5;
                    }

                    break;
            }

            vertical_move = false;
        }
        if (vertical < 0 && vertical_move)
        {//������
            switch (cursor_num)
            {
                case 1:

                    if (select3 != null && select3.activeInHierarchy && old_cursor_num == 3)
                    {
                        CursorMove(select1, select3);

                        cursor_num = 3;

                        old_cursor_num = 1;
                    }
                    else if (select4 != null && select4.activeInHierarchy && old_cursor_num == 4)
                    {
                        CursorMove(select1, select4);

                        cursor_num = 4;

                        old_cursor_num = 1;
                    }
                    else if (select3 != null && select3.activeInHierarchy)
                    {
                        CursorMove(select1, select3);

                        cursor_num = 3;

                        old_cursor_num = 1;
                    }
                    else if (select5 != null && select5.activeInHierarchy)
                    {
                        CursorMove(select1, select5);

                        cursor_num = 5;

                        old_cursor_num = 1;
                    }

                    break;
                case 2:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        CursorMove(select2, select4);

                        cursor_num = 4;

                        old_cursor_num = 2;
                    }
                    else if (select5 != null && select5.activeInHierarchy)
                    {
                        CursorMove(select2, select5);

                        cursor_num = 5;

                        old_cursor_num = 2;
                    }

                    break;
                case 3:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        CursorMove(select3, select5);

                        cursor_num = 5;

                        old_cursor_num = 3;
                    }

                    break;
                case 4:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        CursorMove(select4, select5);

                        cursor_num = 5;

                        old_cursor_num = 4;
                    }

                    break;
                case 5:

                    

                    break;
            }

            vertical_move = false;
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

    public void SetCursorPos(GameObject select)
    {
        RectTransform select_RecTr = select.GetComponent<RectTransform>();


        if (cursor != null)
        {
            cursor_RecTr.anchoredPosition = new Vector2(select_RecTr.anchoredPosition.x + (select_RecTr.sizeDelta.x / 2),
                                                      select_RecTr.anchoredPosition.y + (select_RecTr.sizeDelta.y / 20));

        }
        
    }

    void CursorMove(GameObject old_select, GameObject select)
    {
        ButtonSelectRemove(old_select);

        SetCursorPos(select);
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
