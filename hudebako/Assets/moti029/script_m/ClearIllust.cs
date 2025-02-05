using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{�^���������ƃQ�[���N���A�V�[���ɔ�΂��悤�ɕύX�\��

//����
/*
�X�e�[�W10�̊��ɐG��ăX�e�[�W�N���A�̕��������ꂽ���
�t�F�[�h�A�E�g���Ă���Q�[���N���A�V�[���ɔ�΂�
�X�e�[�W�Z���N�g�V�[���ɖ߂��Ă�����X�e�[�W9�̉��ɃN���A�G�\���{�^����\��
���̃{�^���������ƍēx�Q�[���N���A�V�[���ɔ��(Esc�L�[�ŃX�e�[�W�Z���N�g�V�[���Ɉړ�)
�ēx�Q�[���N���A�V�[���ɔ�񂾏ꍇ�̓N���A�G�̂ݕ\������悤�ɂ���
����N���A���̓N���A�G�\���̂ق��ɉ��o��ǉ�����H
 */
public class ClearIllust : MonoBehaviour
{
    [SerializeField] public GameObject Clear_Illust_Open; //�N���A�G���J���{�^��������
    [SerializeField] public GameObject Clear_Illust_Close; //�N���A�G�����{�^��������
    [SerializeField] public GameObject GameClearPanel; //�J���{�^���E����{�^�����܂Ƃ߂��p�l��������

    [Header("���莞�ɖ炷SE")] public AudioClip enter;
    [Header("�L�����Z�����ɖ炷SE")] public AudioClip cancel;

    bool IllustPanelOpen = false;    //�N���A�p�l����\�����Ă��邩(true:�\�� false:��\��)
    bool IllustOpen = false;    //�N���A�G��\�����Ă��邩(true:�\�� false:��\��)


    //�X�^�[�g�֐�
    // Start is called before the first frame update
    void Start()
    {
        GameClearPanel.SetActive(true);
        Clear_Illust_Open.SetActive(false);
        Clear_Illust_Close.SetActive(false);
        IllustPanelOpen = false;
        IllustOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�S�X�e�[�W�N���A��ɃN���A�G�����邽�߂̃V�[���Ɉړ����邽�߂̃{�^����\��
        //(���݂̓X�e�[�W1���N���A���Ă��Ȃ��ꍇ�̂ݕ\��)
        if (StageClearManager.clearlevel == 0 && Panel_Manager_m.page_num == 2)
        //�S�X�e�[�W�N���A�������ƃX�e�[�W9�̉��Ƀ{�^����\��
        {
            IllustPanelOpen = true;
            Debug.Log("�N���A�G�p�l���\��");
        }
        else
        {
            IllustPanelOpen = false;
            Debug.Log("�N���A�G�p�l����\��");
        }


        //�N���A�G��\�������邽�߂̕ϐ�(0:�S�Ĕ�\�� 1:�\���{�^����\�� 2:�N���A�G��\�� 3:)

        //switch (IllustNum)
        //{
        //    case 0://�N���A�G�p�l���\���E�{�^���A�N���A�G��\��
        //        GameClearPanel.SetActive(true);
        //        Clear_Illust_Open.SetActive(false);
        //        Clear_Illust_Close.SetActive(false);
        //        break;
        //    case 1://�{�^���\���E�N���A�G��\��
        //        Clear_Illust_Open.SetActive(true);
        //        Clear_Illust_Close.SetActive(false);
        //        break;
        //    case 2://�{�^����\���E�N���A�G�\��
        //        Clear_Illust_Open.SetActive(false);
        //        Clear_Illust_Close.SetActive(true);
        //        break;
        //}
        if (IllustPanelOpen)//IllustPanelOpen��true�Ȃ�
        {
            //�N���A�G�p�l���\���E�{�^���A�N���A�G��\��
            GameClearPanel.SetActive(true);
            Clear_Illust_Open.SetActive(true);
            Clear_Illust_Close.SetActive(false);
        }
        else
        {
            //false�Ȃ�S�Ĕ�\��
            GameClearPanel.SetActive(true);
            Clear_Illust_Open.SetActive(false);
            Clear_Illust_Close.SetActive(false);
        }

        //if (IllustOpen)//IllustOpen��true�Ȃ�
        //{
        //    Clear_Illust_Close.SetActive(true);
        //    Debug.Log("�N���A�G��\��");

        //}


        //if (IllustOpen == true)
        //{
        //    //Escape�L�[���������ƃX�e�[�W�Z���N�g��ʂɖ߂�
        //    if (Input.GetKey(KeyCode.Escape))
        //    {
        //        IllustOpen = false;
        //        Debug.Log("�G�����");
        //    }


        //}


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
    /// �����ƃN���A�V�[���Ɉړ�
    /// </summary>
    public void Enter_Event()
    {
        //IllustOpen = true;
        Debug.Log("�N���A�V�[���ֈړ�");
    }

    //public void Close_Event()
    //{
    //    IllustNum = 1;
    //    Debug.Log("�G�����");
    //}
    public void PlaySE()
    {
        if (IllustOpen)
        {
            SceneChenger.instance.PlaySE(enter);
            Debug.Log("enterSE��炷");
        }
        else
        {
            SceneChenger.instance.PlaySE(cancel);
            Debug.Log("canselSE��炷");
        }
    }
}

