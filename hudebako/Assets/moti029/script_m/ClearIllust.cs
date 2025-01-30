using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearIllust : MonoBehaviour
{
    [SerializeField] public GameObject Clear_Illust_Open; //�N���A�G���J���{�^��������
    [SerializeField] public GameObject Clear_Illust_Close; //�N���A�G�����{�^��������
    [SerializeField] public GameObject GameClearPanel; //�J���{�^���E����{�^�����܂Ƃ߂��p�l��������

    //bool ClearEvent = false;    //�S�[���������ɂP�x�����N���A�G��\������
    //int StageClearCount;    //�ēx�X�e�[�W���N���A���ɃN���A�G���\������Ȃ��悤�ɂ���
    int IllustNum;    //�N���A�G��\�������邽�߂̕ϐ�(0:�S�Ĕ�\�� 1:�\���{�^����\�� 2:�N���A�G��\�� 3:)

    //�X�^�[�g�֐�
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
        IllustNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�e�[�W10�N���A��
        //if (PlayerController.gameState == "clear" && ClearEvent == false && StageClearCount == 0)
        //{
        //    GameClearPanel.SetActive(true);
        //    Illust_Close();
        //    Debug.Log("1�x�����N���A����");
        //}

        //�S�X�e�[�W�N���A��ɃN���A�G��\������(���݂͕\�����Ȃ�)
        if (StageClearManager.clearlevel == 0 && Panel_Manager_m.page_num == 2)
        //�S�X�e�[�W�N���A�������ƃX�e�[�W9��10���\������Ă���ꏊ��
        {
            IllustNum = 1;
            Debug.Log("IllustNum = 1");
        }
        else
        {
            IllustNum = 0;
            Debug.Log("IllustNum = 0");
        }

        //if (IllustNum == 2)
        //{

        //}

        //�N���A�G��\�������邽�߂̕ϐ�(0:�S�Ĕ�\�� 1:�\���{�^����\�� 2:�N���A�G��\�� 3:)

        switch (IllustNum)
        {
            case 0://�N���A�G�p�l���\���E�{�^���A�N���A�G��\��
                GameClearPanel.SetActive(true);
                Clear_Illust_Open.SetActive(false);
                Clear_Illust_Close.SetActive(false);
                break;
            case 1://�{�^���\���E�N���A�G��\��
                Clear_Illust_Open.SetActive(true);
                Clear_Illust_Close.SetActive(false);
                break;
            case 2://�{�^����\���E�N���A�G�\��
                Clear_Illust_Open.SetActive(false);
                Clear_Illust_Close.SetActive(true);
                break;
        }

        if (IllustNum == 2)
        {
            //Escape�L�[���������ƃN���A�G���\���ɂ���
            if (Input.GetKey(KeyCode.Escape))
            {
                //Close_Event();
                IllustNum = 1;
                Debug.Log("�G�����");
            }

        }

       





        //public void Illust_Open()//�N���A�G���J���{�^����\������
        //    {
        //        Clear_Illust_Open.SetActive(true);
        //        Clear_Illust_Close.SetActive(false);

        //    }
        //    public void Illust_Close()//�N���A�G�ƕ���{�^����\������
        //    {
        //        Clear_Illust_Close.SetActive(true);
        //        Clear_Illust_Open.SetActive(false);
        //        Debug.Log("�N���A�G��\��");

        //        //Escape�L�[���������ƃN���A�G���\���ɂ���
        //        if (Input.GetKey(KeyCode.Escape))
        //        {
        //            Illust_Open();

        //            //ClearEvent = true;
        //            //StageClearCount++;
        //        }
        //    }

    }
    /// <summary>
    /// �����ƃC���X�g��\������
    /// </summary>
    public void Enter_Event()
    {
        IllustNum = 2;
        Debug.Log("�G���J��");
    }

    //public void Close_Event()
    //{
    //    IllustNum = 1;
    //    Debug.Log("�G�����");
    //}

}
