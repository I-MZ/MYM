using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Panel_Manager_m : MonoBehaviour
{
    [SerializeField] public GameObject Panel0; //1-4�X�e�[�W�p�l��
    [SerializeField] public GameObject Panel1; //5-8�X�e�[�W�p�l��
    [SerializeField] public GameObject Panel2; //9-10�X�e�[�W�p�l��

    [SerializeField] public GameObject Select_R; //�E���{�^��������
    [SerializeField] public GameObject Select_L; //�����{�^��������

    int stage_num;

    [Header("�y�[�W��؂�ւ��鎞��SE")] public AudioClip Paging;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        stage_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage_num == 0)//�X�e�[�W1-4
        {
            Panel0.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Select_L.SetActive(false);
            Select_R.SetActive(true);
        }

        if (stage_num == 1)//�X�e�[�W5-8
        {
            Panel0.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Select_L.SetActive(true);
            Select_R.SetActive(true);
        }

        if (stage_num == 2)//�X�e�[�W9-10
        {
            Panel0.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Select_L.SetActive(true);
            Select_R.SetActive(false);
        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Application.Quit();
        //}
    }

    public void num_plus_R()
    {
        if (stage_num < 2)//�E
        {
            SceneChenger.instance.PlaySE(Paging);
            stage_num++;
        }
       
       
    }
    
    public void num_plus_L()
    {
        
        if (stage_num > 0)//��
        {
            SceneChenger.instance.PlaySE(Paging);
            stage_num--;
        }

       
        
    }

   

    //public void panel_num()//�X�e�[�W1�`10��true.false�؂�ւ�
    //{
    //    if (stage_num == 0)//�X�e�[�W1-4
    //    {
    //        Panel0.SetActive(true);
    //        Panel1.SetActive(false);
    //        Panel2.SetActive(false);
    //        Select_L.SetActive(false);
    //        Select_R.SetActive(true);
    //    }

    //    if (stage_num == 1)//�X�e�[�W5-8
    //    {
    //        Panel0.SetActive(false);
    //        Panel1.SetActive(true);
    //        Panel2.SetActive(false);
    //        Select_L.SetActive(true);
    //        Select_R.SetActive(true);
    //    }

    //    if (stage_num == 2)//�X�e�[�W9-10
    //    {
    //        Panel0.SetActive(false);
    //        Panel1.SetActive(false);
    //        Panel2.SetActive(true);
    //        Select_L.SetActive(true);
    //        Select_R.SetActive(false);
    //    }
    //}


}
