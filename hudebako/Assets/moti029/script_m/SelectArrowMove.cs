using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�
    [SerializeField] public GameObject SelectObject;

    private float coordinate;
    //private float MY = 0.0f;//�㉺�l


    private void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D���擾

    }

    public void SelectObject_Move()//���
    {
       
        //�\������Ă���Ԃ͏㉺�ɓ���
    }

    public void Select_obj_active()//�\����\��
    {

    }
}
