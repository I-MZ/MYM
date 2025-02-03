using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// �J�[�\���̓����𐧌䂷��N���X
/// </summary>
public class CursorController : MonoBehaviour
{
    //�C���X�^���X
    public static CursorController instance = null;

    //�J�[�\��
    public GameObject cursor;           //�J�[�\���̃I�u�W�F�N�g
    private RectTransform cursor_RecTr; //�J�[�\����RectTransform

    //�J�[�\�����ǂ��ɂ��邩
    public int cursor_num;
    
    //�J�[�\�����ЂƂO�ɂǂ��ɂ�����
    private int old_cursor_num;

    //�{�^��(Unity��Őݒ�)
    public GameObject[] Buttons = new GameObject[5];
    public GameObject Nextbutton;
    public GameObject Buckbutton;

    private int[] Bt_num;

    //�{�^���ʒu�C���[�W
    //      0   1  
    //   B  2   3  N
    //        4


    //�Q�[���I���m�F���j���[�̃p�l����
    public bool GameEnd_Cuasor = false;

    //�J�[�\�����A���œ����Ȃ��悤�ɂ��邽�߂̕ϐ�
    private bool horizontal_move = false;   //��
    private bool vertical_move = false;     //�c

    public AudioClip MoveSE;

    

    /// <summary>
    /// ���������s���֐�
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�擾
        instance = GetComponent<CursorController>();
        cursor_RecTr = cursor.GetComponent<RectTransform>();

        //�J�[�\���ʒu�����ݒ�
        if (Buttons[0] != null && Buttons[0].activeInHierarchy)
        {
            SetCursorPos(Buttons[0]);
            cursor_num = 0;
        }
        else//select0����A�N�e�B�u�Ȃ�select4�������ʒu�ɂ���
        {
            SetCursorPos(Buttons[4]);
            cursor_num = 4;
        }
        old_cursor_num = cursor_num;
    }

    //�A�b�v�f�[�g�֐�
    // Update is called once per frame
    void Update()
    {
        //���͊m�F�p���O
        Debug.Log("horizontal = " + Input.GetAxisRaw("Horizontal") + " : horizontal_move = " + horizontal_move);
        Debug.Log("vertical = " + Input.GetAxisRaw("Vertical") + " : vertical_move = " + vertical_move);

        //���͂��m�F����
        CheckInput();

        //
        if (!GameEnd_Cuasor && GameEnd.GameState == "endmode")
        {
            return;
        }

        //Esc�L�[�������ꂽ��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //�J�[�\���ʒu��������
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

        //�J�[�\���������Ă���{�^����I����Ԃɂ���
        for(int i = 0; i < 5; i++)
        {
            if (cursor_num == i)
            {
                ButtonSelect(Buttons[i]);
            }
        }

        CursorControll();

        //Space�L�[�������ꂽ��I������Ă���{�^��������
        if (Input.GetKeyDown(KeyCode.Space)&&(!GameEnd_Cuasor && GameEnd.GameState == "endmode"))
        {
            for (int i = 0; i < 5; i++)
            {
                if (cursor_num == i)
                {
                    Enter(Buttons[i]);
                }
            }
        }

        

    }

    /// <summary>
    /// ���͂��m�F���Ĉړ��̎�t�𐧌䂷��֐�
    /// </summary>
    void CheckInput()
    {
        //������
        if (Input.GetAxisRaw("Horizontal") == 0)
        {//���͂Ȃ��Ȃ�J�[�\���𓮂�����悤�ɂ���
            horizontal_move = true;
        }

        //�c����
        if (Input.GetAxisRaw("Vertical") == 0)
        {//���͂Ȃ��Ȃ�J�[�\���𓮂�����悤�ɂ���
            vertical_move = true;
        }
    }   

    /// <summary>
    /// ���͂ɉ����ăJ�[�\�����ǂ��������𐧌䂷��֐�
    /// </summary>
    void CursorControll()
    {
        if (Input.GetAxisRaw("Horizontal") < 0 && horizontal_move)
        {//������
            switch (cursor_num)
            {
                case 0:
                    //�y�[�W��߂�
                    if (Buckbutton != null && Buckbutton.activeInHierarchy)
                    {
                        ButtonSelectRemove(Buttons[0]);

                        BuckPage();

                        old_cursor_num = 0;
                    }


                    break;
                case 1:
                    //�ꏊ1���ꏊ0
                    if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[1], Buttons[0], 1, 0);
                    }

                    break;
                case 2:
                    //�y�[�W��߂� �ꏊ2���ꏊ0
                    if (Buckbutton != null && Buckbutton.activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[0], 2, 0);

                        BuckPage();

                    }

                    break;
                case 3:
                    //�ꏊ3���ꏊ2
                    if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[3], Buttons[2], 3, 2);
                    }

                    break;
                case 4:
                    //�ꏊ4���ꏊ2
                    if (Buttons[2] != null && Buttons[2].activeInHierarchy)
                    {
                        CursorMove(Buttons[4], Buttons[2], 4, 2);
                    }

                    break;
            }

            horizontal_move = false;
        }
        if (Input.GetAxisRaw("Horizontal") > 0 && horizontal_move)
        {//�E����
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
        {//�����
            switch (cursor_num)
            {
                case 0:

                    

                    break;
                case 1:


                    break;
                case 2:

                    if (Buttons[0] != null && Buttons[0].activeInHierarchy)
                    {
                        CursorMove(Buttons[2], Buttons[0], 2, 0);
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
        {//������
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

    /// <summary>
    /// �J�[�\�����{�^����I��ł���Ƃ��̏����̊֐�
    /// </summary>
    /// <param name="select"></param>
    void ButtonSelect(GameObject select)
    {
        //�󂯎�����{�^����Button�擾
        Button bt = select.GetComponent<Button>();
        //�{�^����I�΂�Ă����Ԃ�
        bt.Select();

        //�󂯎�����{�^����EventTriggerTest�����邩�m�F
        if (select.GetComponent<EventTriggerTest>() != null)
        {//����Ȃ�
            //EventTriggerTest�擾
            EventTriggerTest evt = select.GetComponent<EventTriggerTest>();
            //�C�x���g�N��
            evt.Enter_Event();
        }


    }

    /// <summary>
    /// �J�[�\�����{�^������o���Ƃ��̏����̊֐�
    /// </summary>
    /// <param name="select"></param>
    void ButtonSelectRemove(GameObject select)
    {
        //�󂯎�����{�^����EventTriggerTest�����邩�m�F
        if (select.GetComponent<EventTriggerTest>() != null)
        {
            //EventTriggerTest�擾
            EventTriggerTest evt = select.GetComponent<EventTriggerTest>();
            //�C�x���g�N��
            evt.Exit_Event();
        }
    }

    /// <summary>
    /// �J�[�\����I�΂�Ă���{�^���̉��Ɉړ�������֐�
    /// </summary>
    /// <param name="select"></param>
    public void SetCursorPos(GameObject select)
    {
        //�󂯎�����{�^����RectTransform�擾
        RectTransform select_RecTr = select.GetComponent<RectTransform>();

        //�J�[�\�������邩�m�F
        if (cursor != null)
        {//����Ȃ�
            //�J�[�\�����󂯎�����{�^���̉��Ɉړ�������
            cursor_RecTr.anchoredPosition = new Vector2(select_RecTr.anchoredPosition.x + (select_RecTr.sizeDelta.x / 2),
                                                        select_RecTr.anchoredPosition.y + (select_RecTr.sizeDelta.y / 20));

        }
        
    }

    /// <summary>
    /// �J�[�\�����ړ������鏈�����܂Ƃ߂��֐�
    /// </summary>
    /// <param name="old_select"></param>
    /// <param name="select"></param>
    /// <param name="now_num"></param>
    /// <param name="new_num"></param>
    void CursorMove(GameObject old_select, GameObject select, int now_num, int new_num)
    {
        //�J�[�\�����{�^������o��
        ButtonSelectRemove(old_select);
        //�J�[�\�����ړ�������
        SetCursorPos(select);

        SceneChenger.instance.PlaySE(MoveSE);

        //
        cursor_num = new_num;
        //
        old_cursor_num = now_num;
    }

    /// <summary>
    /// �{�^�����������Ƃ��̏����̊֐�
    /// </summary>
    /// <param name="select"></param>
    void Enter(GameObject select)
    {

        Button bt = select.GetComponent<Button>();
        bt.onClick.Invoke();
              
    }

    /// <summary>
    /// ���̃y�[�W�ɐi�ނƂ��̊֐�
    /// </summary>
    void NextPage()
    {
        Button bt = Nextbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }

    /// <summary>
    /// �O�̃y�[�W�ɖ߂�Ƃ��̊֐�
    /// </summary>
    void BuckPage()
    {
        Button bt = Buckbutton.GetComponent<Button>();
        bt.onClick.Invoke();
    }
}
