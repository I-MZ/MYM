using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{

    public GameObject cursor;
    private int cursor_num = 1;

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
                //
                ButtonSelect(select1);
                break;
            case 2:
                //
                ButtonSelect(select2);
                break;
            case 3:
                //
                ButtonSelect(select3);
                break;
            case 4:
                //
                ButtonSelect(select4);
                break;
            case 5:
                //
                ButtonSelect(select5);
                break;
        }

        CursorMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (cursor_num) 
            {
                case 1:
                    //
                    Enter(select1);
                    break;
                case 2:
                    //
                    Enter(select2);
                    break;
                case 3:
                    //
                    Enter(select3);
                    break;
                case 4:
                    //
                    Enter(select4);
                    break;
                case 5:
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
                        BuckPage();

                    }


                    break;
                case 2:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 3:

                    if (buckbutton != null && buckbutton.activeInHierarchy)
                    {
                        BuckPage();

                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 4:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        SetCursorPos(select3);

                        cursor_num = 3;
                    }

                    break;
                case 5:

                    if ((select3 != null && select3.activeInHierarchy) && (select4 != null && select4.activeInHierarchy))
                    {
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
                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 2:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        NextPage();

                    }

                    break;
                case 3:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        SetCursorPos(select4);

                        cursor_num = 4;
                    }

                    break;
                case 4:

                    if (nextbutton != null && nextbutton.activeInHierarchy)
                    {
                        NextPage();

                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 5:

                    if ((select3 != null && select3.activeInHierarchy) && (select4 != null && select4.activeInHierarchy))
                    {
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
                        SetCursorPos(select1);

                        cursor_num = 1;
                    }

                    break;
                case 4:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        SetCursorPos(select2);

                        cursor_num = 2;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        SetCursorPos(select3);

                        cursor_num = 3;
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
                        SetCursorPos(select3);

                        cursor_num = 3;
                    }

                    break;
                case 2:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        SetCursorPos(select4);

                        cursor_num = 4;
                    }

                    break;
                case 3:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        SetCursorPos(select5);

                        cursor_num = 5;
                    }

                    break;
                case 4:

                    if (select5 != null && select5.activeInHierarchy)
                    {
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
        cursor.transform.position = new Vector3(select.transform.position.x + (select.GetComponent<RectTransform>().sizeDelta.x / 75),
                                                select.transform.position.y,
                                                select.transform.position.z);
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
