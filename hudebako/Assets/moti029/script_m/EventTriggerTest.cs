using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
    [SerializeField] public GameObject SelectObject;        //�X�e�[�W�{�^�����I��������
    [SerializeField] public GameObject SelectObject_arrow;  //���F�̖�󂪃X�e�[�W�{�^���̏�ɕ\��
    public int num;                                         //�ǂ̃X�e�[�W��I�����Ă��邩(1:����2:�E��3:����4:�E��)

    private void Start()
    {
        SelectObject_arrow.SetActive(false);
    }

    public void Enter_Event()
    {

        //
        if (SelectObject)
        {
            if (SelectObject.name == "Stage1_button" ||
                SelectObject.name == "Stage5_button" ||
                SelectObject.name == "Stage9_button")
            {
                Debug.Log("num1");
                num = 1;//���͍���ɕ\�������
            }
            else if (SelectObject.name == "Stage2_button" ||
                     SelectObject.name == "Stage6_button" ||
                     SelectObject.name == "Stage10_button")
            {
                Debug.Log("num2");
                num = 2;//���͉E��ɕ\�������
            }
            else if (SelectObject.name == "Stage3_button" ||
                     SelectObject.name == "Stage7_button" ||
                     SelectObject.name == "Clear")
            {
                Debug.Log("num3");
                num = 3;//���͍����ɕ\�������
            }
            else if (SelectObject.name == "Stage4_button" ||
                     SelectObject.name == "Stage8_button" )
                     
            {
                Debug.Log("num4");
                num = 4;//���͉E���ɕ\�������
            }
            else
            {
                SelectObject_arrow.SetActive(false);
                num = 0;
            }



            //����\���������
            if (num == 1 && SelectObject_arrow.name == "select_arrowUL")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("����\��");
            }
            if (num == 2 && SelectObject_arrow.name == "select_arrowUR")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("�E��\��");
            }
            if (num == 3 && SelectObject_arrow.name == "select_arrowDL")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("�����\��");
            }
            if (num == 4 && SelectObject_arrow.name == "select_arrowDR")
            {
                SelectObject_arrow.SetActive(true);
                Debug.Log("�E���\��");
            }

            //Debug.Log("�C�x���g�����I");
        }
    }

    public void Exit_Event()
    //�����\���ɂ���
    {
        SelectObject_arrow.SetActive(false);//�����\���ɂ���

        Debug.Log("�C�x���g��\���I");
    }
}