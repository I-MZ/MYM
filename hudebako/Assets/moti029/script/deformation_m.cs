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

    bool up_wall = false;       //�㑤�̕�
    bool down_wall = false;     //�����̕�
    bool right_wall = false;    //�E���̕�
    bool left_wall = false;     //�����̕�

    private int gravity = 0;         //�d�͂̌���(0=��,1=��,2=�E,3=��)

    bool onWall = false;            //��(��)�ɏ���Ă��邩
    bool onGravity = false;         //�d�͂��������Ă��邩
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();   //Rigidbody2D������Ă���
        targetGameObject2.SetActive(false);//�ό`�I�u�W�F�N�g�͏����Ă���
    }

    // Update is called once per frame
    void Update()
    {
        Deformation();

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
            down_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && onWall)
        {
            gravity = 1;
            up_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && onWall)
        {
            gravity = 2;
            right_wall = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onWall)
        {
            gravity = 3;
            left_wall = true;

        }
    }
    


    void Deformation()//�ό`
    {
        //���������Ă���Ǒ��Ɍ������Ė��L�[������
        //player��active�Ȃ̂����ׂăA�N�e�B�u�Ɣ�A�N�e�B�u��؂�ւ���

        //�����ɏd�͂��������Ă��鎞
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject1.activeInHierarchy && gravity == 0)
        {
            onGravity = true;
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && targetGameObject2.activeInHierarchy && gravity == 0)
        {
            onGravity = false;
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //�㑤�ɏd�͂��������Ă��鎞
        if (Input.GetKeyDown(KeyCode.UpArrow) && targetGameObject1.activeInHierarchy && gravity == 1)
        {
            onGravity = true;
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && targetGameObject2.activeInHierarchy && gravity == 1)
        {
            onGravity = false;
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //�E
        if (Input.GetKeyDown(KeyCode.RightArrow) && targetGameObject1.activeInHierarchy && onGravity == true)
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && targetGameObject2.activeInHierarchy && onGravity == true)
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

        //��
        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetGameObject1.activeInHierarchy && onGravity == true)
        {
            targetGameObject2.SetActive(true);
            targetGameObject1.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && targetGameObject2.activeInHierarchy && onGravity == true)
        {
            targetGameObject1.SetActive(true);
            targetGameObject2.SetActive(false);
            return;
        }

    }
}
