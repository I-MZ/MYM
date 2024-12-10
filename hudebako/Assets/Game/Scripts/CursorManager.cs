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

    //位置サンプル
    //  1   2  
    //  3   4
    //    5


    // Start is called before the first frame update
    void Start()
    {
        if (select1 != null && select1.activeInHierarchy)
        {
            cursor.transform.position = new Vector3(select1.transform.position.x,
                                                    select1.transform.position.y,
                                                    select1.transform.position.z);

            cursor_num = 1;
        }
        else
        {
            cursor.transform.position = new Vector3(select5.transform.position.x,
                                                     select5.transform.position.y,
                                                     select5.transform.position.z);

            cursor_num = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CursorMove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Enter();
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
                        Enter();

                        cursor.transform.position = new Vector3(select2.transform.position.x,
                                                                select2.transform.position.y,
                                                                select2.transform.position.z);

                        cursor_num = 2;
                    }


                    break;
                case 2:

                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y, 
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }

                    break;
                case 3:


                    break;
                case 4:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select3.transform.position.x,
                                                                select3.transform.position.y,
                                                                select3.transform.position.z);

                        cursor_num = 3;
                    }

                    break;
                case 5:

                    if ((select3 != null && select3.activeInHierarchy) && (select4 != null && select4.activeInHierarchy))
                    {
                        cursor.transform.position = new Vector3(select3.transform.position.x,
                                                                select3.transform.position.y,
                                                                select3.transform.position.z);

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
                        cursor.transform.position = new Vector3(select2.transform.position.x,
                                                                select2.transform.position.y,
                                                                select2.transform.position.z);

                        cursor_num = 2;
                    }

                    break;
                case 2:


                    break;
                case 3:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select4.transform.position.x,
                                                                select4.transform.position.y,
                                                                select4.transform.position.z);

                        cursor_num = 4;
                    }

                    break;
                case 4:


                    break;
                case 5:

                    if ((select3 != null && select3.activeInHierarchy) && (select4 != null && select4.activeInHierarchy))
                    {
                        cursor.transform.position = new Vector3(select4.transform.position.x,
                                                                select4.transform.position.y,
                                                                select4.transform.position.z);

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
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }

                    break;
                case 4:

                    if (select2 != null && select2.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select2.transform.position.x,
                                                                select2.transform.position.y,
                                                                select2.transform.position.z);

                        cursor_num = 2;
                    }

                    break;
                case 5:

                    if (select3 != null && select3.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select3.transform.position.x,
                                                                select3.transform.position.y,
                                                                select3.transform.position.z);

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
                        cursor.transform.position = new Vector3(select3.transform.position.x,
                                                                select3.transform.position.y,
                                                                select3.transform.position.z);

                        cursor_num = 3;
                    }

                    break;
                case 2:

                    if (select4 != null && select4.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select4.transform.position.x,
                                                                select4.transform.position.y,
                                                                select4.transform.position.z);

                        cursor_num = 4;
                    }

                    break;
                case 3:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                select5.transform.position.y,
                                                                select5.transform.position.z);

                        cursor_num = 5;
                    }

                    break;
                case 4:

                    if (select5 != null && select5.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                select5.transform.position.y,
                                                                select5.transform.position.z);

                        cursor_num = 5;
                    }

                    break;
                case 5:

                    

                    break;
            }
        }
    }

    void Enter()
    {
        

        switch (cursor_num)
        {
            case 1:

                if (select1 != null && select1.activeInHierarchy)
                {
                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }
                    else
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                 select5.transform.position.y,
                                                                 select5.transform.position.z);

                        cursor_num = 5;
                    }

                    Button bt = select1.GetComponent<Button>();
                    bt.onClick.Invoke();
                }

                break;
            case 2:

                if (select2 != null && select2.activeInHierarchy)
                {
                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }
                    else
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                 select5.transform.position.y,
                                                                 select5.transform.position.z);

                        cursor_num = 5;
                    }

                    Button bt = select2.GetComponent<Button>();
                    bt.onClick.Invoke();
                }

                break;
            case 3:

                if (select3 != null && select3.activeInHierarchy)
                {
                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }
                    else
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                 select5.transform.position.y,
                                                                 select5.transform.position.z);

                        cursor_num = 5;
                    }

                    Button bt = select3.GetComponent<Button>();
                    bt.onClick.Invoke();
                }

                break;
            case 4:

                if (select4 != null && select4.activeInHierarchy)
                {
                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }
                    else
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                 select5.transform.position.y,
                                                                 select5.transform.position.z);

                        cursor_num = 5;
                    }

                    Button bt = select4.GetComponent<Button>();
                    bt.onClick.Invoke();
                }

                break;
            case 5:

                if (select5 != null && select5.activeInHierarchy)
                {
                    if (select1 != null && select1.activeInHierarchy)
                    {
                        cursor.transform.position = new Vector3(select1.transform.position.x,
                                                                select1.transform.position.y,
                                                                select1.transform.position.z);

                        cursor_num = 1;
                    }
                    else
                    {
                        cursor.transform.position = new Vector3(select5.transform.position.x,
                                                                 select5.transform.position.y,
                                                                 select5.transform.position.z);

                        cursor_num = 5;
                    }

                    Button bt = select5.GetComponent<Button>();
                    bt.onClick.Invoke();
                }

                break;
        }

    }
}
