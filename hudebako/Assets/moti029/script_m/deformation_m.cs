using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class deformation_m : MonoBehaviour
{
    Rigidbody2D rbody;              //Rigidbody2D�^�̕ϐ�
    [SerializeField] public GameObject targetGameObject1; //�ʏ�I�u�W�F�N�g������
    [SerializeField] public GameObject targetGameObject2; //�ό`�I�u�W�F�N�g������

    public float movespeed = 1.0f;  //�ړ����x
    private float inputH = 0.0f;      //������
    private float inputV = 0.0f;      //�c����

    private int gravity = 0;         //�d�͂̌���(0=��,1=��,2=�E,3=��)

    bool onWall = false;            //��(��)�ɏ���Ă��邩
    bool onGravity = false;         //�d�͂��������Ă��邩

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        //targetGameObject1.SetActive(true);//�ʏ�I�u�W�F�N�g�\��
        targetGameObject2.SetActive(false);//�ό`�I�u�W�F�N�g�͏����Ă���
    }

    // Update is called once per frame
    void Update()
    {
        ChangeGravity();
        Deformation_all();
        

        if (targetGameObject1.activeInHierarchy)
        {
            targetGameObject2.transform.position = targetGameObject1.transform.position;
        }
        if (targetGameObject2.activeInHierarchy)
        {
            targetGameObject1.transform.position = targetGameObject2.transform.position;
        }

        

    }
    private void FixedUpdate()
    {
       
        if (onWall)
        {
            if (gravity == 0 || gravity == 1)//���A��
            {
                rbody.velocity = new Vector2(movespeed * inputH, rbody.velocity.y);
            }
            else//�E�A��
            {
                rbody.velocity = new Vector2(rbody.velocity.x, movespeed * inputV);
            }
        }

    }

    void ChangeGravity()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall)
        {
            gravity = 0;
        }       
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall)
        {
            gravity = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall)
        {
            gravity = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall)
        {
            gravity = 3;
        }

        //�����̏��ɂ��Ă��ĉ��L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity == 0)
        {
            if (!onGravity)//�d�͂������Ȃ����
            {
                onGravity = true;//�d�͂���������
            }
            else//�d�͂��������
            {
                onGravity = false;//�d�͂���߂�
            }
        } //�㑤�̏��ɂ��Ă��ď�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity == 1)
        {
            if (!onGravity)//�d�͂������Ȃ����
            {
                onGravity = true;//�d�͂���������
            }
            else//�d�͂��������
            {
                onGravity = false;//�d�͂���߂�
            }

        } //�E���̏��ɂ��Ă��ĉE�L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity == 2)
        {
            if (!onGravity)//�d�͂������Ȃ����
            {
                onGravity = true;//�d�͂���������
            }
            else//�d�͂��������
            {
                onGravity = false;//�d�͂���߂�
            }

        } //�����̏��ɂ��Ă��č��L�[�������ꂽ�Ƃ�
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity == 3)
        {
            if (!onGravity)//�d�͂������Ȃ����
            {
                onGravity = true;//�d�͂���������
            }
            else//�d�͂��������
            {
                onGravity = false;//�d�͂���߂�
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && onWall && gravity != 0)
        {
            gravity = 0;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall && gravity != 1)
        {
            gravity = 1;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall && gravity != 2)
        {
            gravity = 2;
            onGravity = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall && gravity != 3)
        {
            gravity = 3;
            onGravity = false;
        }


    }


    void Deformation_all()
    {
        if (onGravity == true)
        {
            Deformation();
        }
        if (onGravity == false)
        {
            Deformation_release();
        }

        void Deformation()//�ό`�A�j���[�V�����Đ�
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
        }
    
        void Deformation_release()//�ό`�����A�j���[�V�����Đ�
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
        }

        
    }


   
}
