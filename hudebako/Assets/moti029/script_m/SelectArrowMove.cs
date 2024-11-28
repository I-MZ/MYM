using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectArrowMove : MonoBehaviour
{
    Rigidbody2D rbody;                   //Rigidbody2D�^�̕ϐ�
    [SerializeField] public GameObject SelectObject;

    //private float coordinate;
    public float MoveY;
    public float UD_value = 2;
     Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;//�����n�߂�ʒu
    }

    private void Update()
    {
        MoveY -=0.05f;//�㉺�ړ��l

        //posY�ɏ����ʒu+�ʒu����ɂ��炷+-1.005����1.005�܂ł̒l*UD_value(�㉺�l)*1/10
        float posY = startPos.y + Mathf.Sin(MoveY) * (UD_value * 1/10);
        //Mathf.Sin(Time.time) ... -1����1�܂ł̒l��Ԃ�
        //floatY��position�ɑ�����ď㉺�Ɉړ�������
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    public void Exit_Move()
    {
        SelectObject.transform.position = startPos;//�ʒu��������
        //�ړ��ʂ�0�ɂ��ē������~�߂�
        MoveY = 0;
        Debug.Log("���������Z�b�g");

    }

}
