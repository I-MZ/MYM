using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    //===== ��`�̈� =====
    private Animator anim;  //Animator��anim�Ƃ����ϐ��Œ�`����

    //===== �������� =====
    void Start()
    {

        //�ϐ�anim�ɁAAnimator�R���|�[�l���g��ݒ肷��
        anim = gameObject.GetComponent<Animator>();
    }

    //===== �又�� =====
    void Update()
    {
        //�����A�X�y�[�X�L�[�������ꂽ��Ȃ�
        if (Input.GetKey(KeyCode.Space))
        {
            //Bool�^�̃p�����[�^�[�ł���blRot��True�ɂ���
            anim.SetBool("bl_ani", true);
        }
    }
}
