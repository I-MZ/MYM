using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�

    [SerializeField] public GameObject TargetObject;//��̖��
    [SerializeField] public GameObject UpSelectObject;//��̖��
    [SerializeField] public GameObject DownSelectObject;//���̎l�p

    private float coordinate;
    private float MY = 0.0f;//�㉺�l
    

    private void Start()
    {
        UpSelectObject.SetActive(false);
        DownSelectObject.SetActive(false);
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D���擾
    }

    public void UpSelectObject_Move()//����
    {
        UpSelectObject.SetActive(true);
        //�}�E�X���{�^���ɐG��Ă���ԁA���̃{�^���̍��W�ɕ\��


        //�\������Ă���Ԃ͏㉺�ɓ���


    }

    public void DownSelectObject_Move()//���l�p
    {
        DownSelectObject.SetActive(true);
        //�}�E�X���{�^���ɐG��Ă���ԁA���̃{�^���̍��W�ɕ\��
    }

}
