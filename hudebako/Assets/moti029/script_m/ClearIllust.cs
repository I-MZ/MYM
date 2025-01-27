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

    //�X�^�[�g�֐�
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
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
        if (StageClearManager.clearlevel == 12 && Panel_Manager_m.page_num == 2)
            //�S�X�e�[�W�N���A�������ƃX�e�[�W9��10���\������Ă���ꏊ��
        {
            //GameClearPanel.SetActive(true);//�N���A�G�Ɋւ���p�l����\��
            Illust_Open();//�N���A�G��\������{�^����\��
        }
        else
        {
            Clear_Illust_Open.SetActive(false);//�N���A�G��\������{�^�����\��
        }
    }

    
  


    public void Illust_Open()//�N���A�G���J���{�^����\������
    {
        Clear_Illust_Open.SetActive(true);
        Clear_Illust_Close.SetActive(false);

    }
    public void Illust_Close()//�N���A�G�ƕ���{�^����\������
    {
        Clear_Illust_Close.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Debug.Log("�N���A�G��\��");

        //Escape�L�[���������ƃN���A�G���\���ɂ���
        if (Input.GetKey(KeyCode.Escape))
        {
            Illust_Open();

            //ClearEvent = true;
            //StageClearCount++;
        }
    }

}
