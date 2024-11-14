using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class changeScene : MonoBehaviour
{
    [SerializeField] public GameObject title_button; //�^�C�g���{�^��������
    [SerializeField] public GameObject Stage1_button; //�X�e�[�W1�{�^��������
    [SerializeField] public GameObject Stage2_button; //�X�e�[�W2�{�^��������
    [SerializeField] public GameObject Stage3_button; //�X�e�[�W3�{�^��������
    [SerializeField] public GameObject Stage4_button; //�X�e�[�W4�{�^��������

    [SerializeField] public GameObject Stage5_button; //�X�e�[�W5�{�^��������


    [SerializeField] public GameObject Select_R; //�E���{�^��������
    [SerializeField] public GameObject Select_L; //�����{�^��������



    public void change_button()
    {
       //�^�C�g����ʂ���Z���N�g��ʂ�
        if (title_button)
        {
            SceneManager.LoadScene("Stage_Select_Scene_m", LoadSceneMode.Single);
        } 
        
        //�Z���N�g��ʂ���X�e�[�W1
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage1_button)
        {
            SceneManager.LoadScene("Stage1", LoadSceneMode.Single);
        }
        
        //�Z���N�g��ʂ���X�e�[�W2
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage2_button)
        {
            SceneManager.LoadScene("Stage2", LoadSceneMode.Single);
        }
        
        //�Z���N�g��ʂ���X�e�[�W3
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage3_button)
        {
            SceneManager.LoadScene("Stage3", LoadSceneMode.Single);
        }
        
        //�Z���N�g��ʂ���X�e�[�W4
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage4_button)
        {
            SceneManager.LoadScene("Stage4", LoadSceneMode.Single);
        }
        
        //�Z���N�g��ʂ���X�e�[�W5
        if (SceneManager.GetActiveScene().name == "Stage_Select_Scene_m" && Stage5_button)
        {
            SceneManager.LoadScene("Stage5", LoadSceneMode.Single);
        }
        
        
    }

    public void select_LR()//�N���b�N�����{�^���̏�������
    {
        if ()
        {
            Stage1_button = stage5_button;
            Select_R.SetActive(false);
        }
        
    }
}


